// ParseDefCsv.cs: Parse parameter definitions file (CSV)

/* Copyright (C) 2015 SubaruDieselCrew
 *
 * This file is part of ParsePID.
 *
 * ParsePID is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * ParsePID is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with ParsePID.  If not, see <http://www.gnu.org/licenses/>.
 */


using System;
using System.Collections.Generic;
using System.IO;

namespace ParsePID
{
	public sealed class ParseDefCsv : IDisposable
	{
		const string Comment = "#";
		// for parsing integers, cannot use const
		static readonly System.Globalization.NumberFormatInfo NumberFormatInfoInvariant = System.Globalization.NumberFormatInfo.InvariantInfo;

		readonly StreamReader sr;
		readonly char[] separators;

		public ParseDefCsv (string path, char separator)
		{
			var fs = File.OpenRead (path);
			this.sr = new StreamReader (fs);
			this.separators = new char[] { separator };
		}

		public bool Parse (out List<Parameter> parameters)
		{
			parameters = new List<Parameter> (64);

			// skip first line = header row
			sr.ReadLine ();

			string line;
			while ((line = sr.ReadLine ()) != null) {
				if (line.StartsWith (Comment) || string.IsNullOrEmpty (line))
					continue;
				try {
					Parameter p = ParseLine (line);
					parameters.Add (p);
				} catch (Exception ex) {
					throw new InvalidDataException ("Error parsing line:\n" + line, ex);
				}
			}

			return true;
		}

		Parameter ParseLine (string line)
		{
			var p = new Parameter ();

			string[] splitted = line.Split (separators, StringSplitOptions.None);

			p.PID = (UInt16)ParseHexInt (splitted [(int)CsvColumn.PID]);
			p.NameShort = splitted [(int)CsvColumn.Name_Short];
			p.NameFull = splitted [(int)CsvColumn.Name_Full];
			p.Units = splitted [(int)CsvColumn.Units];
			p.Length = byte.Parse (splitted [(int)CsvColumn.Length]);

			return p;
		}

		/// <summary>
		/// Parses hex number e.g."0x123af". Prefix "0x" is required.
		/// </summary>
		static internal int ParseHexInt (string strToParse)
		{
			const string HexPrefix = "0x";

			// prefix "0x" required
			// but not allowed in int.Parse(...) even though using NumberStyles.HexNumber.
			int indexPrefix = strToParse.IndexOf (HexPrefix);
			if (indexPrefix < 0) {
				throw new InvalidDataException ("Prefix '" + HexPrefix + "' missing.");
			}
			return int.Parse (strToParse.Substring (indexPrefix + HexPrefix.Length),
				System.Globalization.NumberStyles.HexNumber, NumberFormatInfoInvariant);
		}


		#region IDisposable implementation

		public void Dispose ()
		{
			sr.Dispose ();
		}

		#endregion
	}
}
