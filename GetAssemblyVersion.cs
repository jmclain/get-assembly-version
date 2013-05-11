#region License
// 
// Author: Joe McLain <nmp.developer@outlook.com>
// Copyright (c) 2013, Joe McLain and Digital Writing
// 
// Licensed under Eclipse Public License, Version 1.0 (EPL-1.0)
// See the file LICENSE.txt for details.
// 
#endregion
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace GetAssemblyVersion {

	public class Program {

		/////////////////////////////////////////////////////////////////////////////

		static void Die( string fmt, params object [] args )
		{
			Console.SetOut( Console.Error );
			Console.WriteLine( fmt, args );
			Environment.Exit( 1 );
		}

		/////////////////////////////////////////////////////////////////////////////
		
		public static int Main( string [] args )
		{
			// ******
			if( 0 == args.Length ) {
				Console.WriteLine( "getAssemblyVersion <path to assembly>" );
				return 1;
			}

			// ******
			var path = args [ 0 ];

			try {

				// ******
				if( !File.Exists( path ) ) {
					Die( "could not locate file {0}", path );
				}

				// ******
				var assembly = Assembly.LoadFrom( path );
				if( null == assembly ) {
					Die( "could not load assembly {0}", path );
				}

				var verStr = assembly.GetName().Version.ToString();
				//
				// only want first 3 numbers
				//
				Console.Write( verStr.Substring( 0, verStr.LastIndexOf('.')) );

				// ******
				return 0;
			}
			catch( Exception ex ) {
				Die( "could not read assembly version for \"{0}\"\nexception: {0}", path, ex.Message );
			}

			// ******
			return 1;
		}



	}



}