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
		const bool IncludeSupportPIDs = true;
		const string folder = "data";

		static string defsPath = System.IO.Path.Combine (folder, "Subaru_mode22_def.csv");
		static string responsesPath = System.IO.Path.Combine (folder, "2015 Forester Diesel CVT Responses.txt");

		const char CsvSeparator = '\t';

		static List<Parameter> parameters;
		static List<SupportResponse> supportResponses;

		static List<Parameter> parametersSupported = new List<Parameter> (256);

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

			// check PIDs, generate results
			foreach (var r in supportResponses) {
				if (IncludeSupportPIDs) {
					SearchAddParameter (r.PID);
				}
				ProcessParameterSupport (r);
			}
			// sort by PID and remove duplicates (SupportPIDs)
			var results = parametersSupported.OrderBy (p => p.PID).Distinct (new ParameterPIDComparer ()).ToList ();

			// output results
			Console.WriteLine ("\nResults:");
			foreach (var p in results) {
				PrintParameter (p);
			}

			int countSupportedKnown = results.Count (p => p.IsDefined);
			int countSupportedUnknown = results.Count - countSupportedKnown;

			Console.WriteLine ("Supported PIDs total: {0} | known: {1} | unknown: {2}",
				results.Count, countSupportedKnown, countSupportedUnknown);

			return 0;
		}

		static void SearchAddParameter (UInt16 pid)
		{
			var parameter = parameters.SingleOrDefault (p => p.PID == pid);
			if (parameter == null) {
				// definition is missing, PID is supported but unknown
				parameter = new Parameter (pid);
			}
			parametersSupported.Add (parameter);
		}

		static void ProcessParameterSupport (SupportResponse r)
		{
			var supportedPIDs = Support.GetSupportedPIDs (r.SupportValue, r.PID, IncludeSupportPIDs);
			foreach (var pid in supportedPIDs) {
				SearchAddParameter (pid);
			}
		}

		static void PrintParameter (Parameter parameter)
		{
			Console.WriteLine ("PID 0x{0:X4} : {1} [{2}]", parameter.PID, parameter.NameFull, parameter.Units);
		}
	}
}
