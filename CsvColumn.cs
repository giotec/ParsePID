// CsvColumn.cs: Enumeration for CSV file columns.

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


namespace ParsePID
{
	/// <summary>
	/// CSV file column indices, must match file layout.
	/// </summary>
	public enum CsvColumn
	{
		PID,
		EngineTypes,
		Authentication,
		Name_Short,
		Name_Full,
		Length,
		Type,
		DataType_Raw,
		Formula,
		Formula_Bytes,
		Units,
		DisplayMin,
		DisplayMax,
		Enumerations,
		Description,
		SSM2_Reference
	}
}
