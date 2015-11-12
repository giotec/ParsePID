// Parameter.cs: Parameter definition class.

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

namespace ParsePID
{
	// TODO add more properties
	public sealed class Parameter
	{
		UInt16 pid;
		string nameFull, nameShort, units;
		byte length;


		public UInt16 PID {
			get { return pid; }
			set { pid = value; }
		}

		public string NameFull {
			get { return nameFull; }
			set { nameFull = value; }
		}

		public string NameShort {
			get { return nameShort; }
			set { nameShort = value; }
		}

		public string Units {
			get { return units; }
			set { units = value; }
		}

		public byte Length {
			get { return length; }
			set { length = value; }
		}

		public Parameter ()
		{
		}

		public override string ToString ()
		{
			return string.Format ("[Parameter: PID={0:X4} | NameFull={1} | Units={2} | Length={3}]",
				PID, NameFull, Units, Length);
		}
	}
}
