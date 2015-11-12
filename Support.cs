// Support.cs: Static helper methods.

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

namespace ParsePID
{
	public static class Support
	{
		public static bool GetBit (this int value, int standardBitNr)
		{
			return (value & (1 << standardBitNr)) != 0;
		}

		/// <summary>
		/// Determines if PID is supported in the specified support value.
		/// </summary>
		/// <returns><c>true</c> if PID is supported; otherwise, <c>false</c>.</returns>
		/// <param name="supportValue">Support value.</param>
		/// <param name="bitNr">Bitnumber according to OBD-II standard: 1 is leftmost = significant bit, 32 is rightmost = LSB.</param>
		public static bool IsPIDSupported (UInt32 supportValue, int bitNr)
		{
			if (bitNr < 1 || bitNr > 32)
				throw new ArgumentOutOfRangeException ("bitNr", "0 <= bitNr <= 32 required");
			return GetBit ((int)supportValue, 32 - bitNr);
		}

		public static List<UInt16> GetSupportedPIDs (UInt32 supportValue, UInt16 startPID, bool includeNextSupportPID)
		{
			var list = new List<UInt16> (32);

			int endBit = includeNextSupportPID ? 32 : 31;
			for (int bitNr = 1; bitNr <= endBit; bitNr++) {
				if (IsPIDSupported (supportValue, bitNr)) {
					list.Add ((UInt16)(startPID + (UInt16)bitNr));
				}
			}

			return list;
		}
	}
}
