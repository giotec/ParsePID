// ParseSupportResponses.cs: Parse file containing responses (hex bytes).

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
	public sealed class ParseSupportResponses : IDisposable
	{
		const string Comment = "#";

		readonly StreamReader sr;
		readonly string[] separators = new string[] { " " };

		public ParseSupportResponses (string path)
		{
			var fs = File.OpenRead (path);
			this.sr = new StreamReader (fs);
		}

		public bool Parse (out List<SupportResponse> list)
		{
			list = new List<SupportResponse> (64);

			string line;
			while ((line = sr.ReadLine ()) != null) {
				if (line.StartsWith (Comment) || string.IsNullOrEmpty (line))
					continue;
				try {
					SupportResponse p = ParseLine (line);
					list.Add (p);
				} catch (Exception ex) {
					throw new InvalidDataException ("Error parsing line:\n" + line, ex);
				}
			}

			return true;
		}

		SupportResponse ParseLine (string line)
		{
			var r = new SupportResponse ();

			var bytes = ParseHexBytes (line, separators);

			r.PID = (UInt16)ParseUIntBigEndian (bytes, 1, 2);
			r.SupportValue = (UInt32)ParseUIntBigEndian (bytes, 3, 4);

			return r;
		}

		public static byte[] ParseHexBytes (string s, string[] separators)
		{
			// multiple separators (spaces) are allowed for nicer display
			string[] splitted = s.Split (separators, StringSplitOptions.RemoveEmptyEntries);
			int length = splitted.Length;

			var bytes = new byte[length];
			for (int i = 0; i < length; i++) {
				bytes [i] = byte.Parse (splitted [i], System.Globalization.NumberStyles.HexNumber);
			}
			return bytes;
		}

		public static UInt64 ParseUIntBigEndian (byte[] bytes, int index, int count)
		{
			if (count < 1 || count > 8)
				throw new ArgumentOutOfRangeException ("count", "1 <= count <= 8 required");

			UInt64 result = 0;
			int shiftAmount = 8 * (count - 1);
			for (int i = 0; i < count; i++, shiftAmount -= 8) {
				result += (UInt64)(bytes [index + i] << shiftAmount);
			}
			return result;
		}

		#region IDisposable implementation

		public void Dispose ()
		{
			sr.Dispose ();
		}

		#endregion
	}
}
