// Program.cs: Console application main class.

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
using System.Linq;

namespace ParsePID
{
	static class MainClass
	{
		const string folder = "data";

		static string defsPath = System.IO.Path.Combine (folder, "Subaru_mode22_def.csv");
		static string responsesPath = System.IO.Path.Combine (folder, "2015 Forester Diesel CVT Responses.txt");

		const char CsvSeparator = '\t';

		static List<Parameter> parameters;
		static List<SupportResponse> supportResponses;

		static int countSupportedKnown = 0, countSupportedUnknown = 0;

		public static int Main (string[] args)
		{
			responsesPath = args.Length > 0 ? args [0] : responsesPath;
			defsPath = args.Length > 1 ? args [1] : defsPath;

			Console.WriteLine ("ParsePID: Parse Subaru OBD-II mode 22 definitions and support responses.");
			Console.WriteLine ("Usage:");
			Console.WriteLine ("ParsePID.exe <ResponseFile> <DefinitionsFile>");
			Console.WriteLine ("or: ParsePID.exe <ResponseFile>");
			Console.WriteLine ("or for using predefined file paths: ParsePID.exe\n");

			if (!System.IO.File.Exists (defsPath)) {
				Console.Error.WriteLine ("ERROR: Definitions file not found: \"{0}\"", defsPath);
				return 2;
			}

			if (!System.IO.File.Exists (responsesPath)) {
				Console.Error.WriteLine ("ERROR: Response file not found: \"{0}\"", responsesPath);
				return 2;
			}

			Console.WriteLine ("Parsing parameter definitions from file \"{0}\"", defsPath);
			using (var parser = new ParseDefCsv (defsPath, CsvSeparator)) {
				if (!parser.Parse (out parameters))
					return 1;
			}
			Console.WriteLine ("Parsed {0} parameters.", parameters.Count);

			Console.WriteLine ();

			Console.WriteLine ("Parsing support responses from file \"{0}\"", responsesPath);
			using (var parser = new ParseSupportResponses (responsesPath)) {
				if (!parser.Parse (out supportResponses))
					return 1;
			}
			foreach (var item in supportResponses) {
				Console.WriteLine (item);
			}
			Console.WriteLine ("Parsed {0} support responses.", supportResponses.Count);


			Console.WriteLine ("\nResults:");

			foreach (var r in supportResponses) {
				PrintParameterSupport (r);
			}
			Console.WriteLine ("Supported PIDs total: {0} | known: {1} | unknown: {2}",
				countSupportedKnown + countSupportedUnknown, countSupportedKnown, countSupportedUnknown);

			return 0;
		}

		static void PrintParameterSupport (SupportResponse r)
		{
			const bool IncludeNextSupportPID = false;

			var supportedPIDs = Support.GetSupportedPIDs (r.SupportValue, r.PID, IncludeNextSupportPID);
			foreach (var pid in supportedPIDs) {
				var parameter = parameters.SingleOrDefault (p => p.PID == pid);

				Console.Write ("PID 0x{0:X4} : ", pid);

				if (parameter != null) {
					++countSupportedKnown;
					Console.WriteLine ("{0} [{1}]", parameter.NameFull, parameter.Units);
				} else {
					++countSupportedUnknown;
					Console.WriteLine ("N/A");
				}
			}
		}
	}
}
