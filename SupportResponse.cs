// SupportResponse.cs: Structure for holding parsed response data.

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
	public struct SupportResponse
	{
		public UInt16 PID;
		public UInt32 SupportValue;

		public override string ToString ()
		{
			return string.Format ("[SupportResponse: PID=0x{0:X4} | SupportValue=0x{1:X8}]",
				PID, SupportValue);
		}

		public override int GetHashCode ()
		{
			return PID | (int)SupportValue;
		}
	}
}
