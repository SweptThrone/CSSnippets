using System.IO;
using System;

/*
Name:  GMod Weapon Unpacker
Author:  SweptThrone (sweptthr.one)
Description:  A console app that unpacks GMod SWeps from file structure
              weapons/classname/shared.lua
              to
              weapons/classname.lua
              with drag-n-drop support.
              If your weapon has init and/or cl_init files, this will ignore them.
Config:  .NET Framework 4.8, C# 7.3, compiler version 4.7.0-3.23416.8 (43b0b05c)
*/

namespace WeaponUnpacker {
    internal class WeaponUnpacker {
        static void Main( string[] args ) {
            string path;

            // this will unpack an entire folder of weapons
            Console.Write( "Enter the path to a folder of weapons to unpack > " );
            path = Console.ReadLine();

            if ( path == null ) {
                Console.WriteLine( "Path is null, try again" );
            } else {
                string[] folders = Directory.GetDirectories( path, "*" );

                foreach ( string folder in folders ) {
                    string file = Directory.GetFiles( folder )[ 0 ];
                    string gunName = new DirectoryInfo( folder ).Name;
                    File.Copy( file, path + "\\" + gunName + ".lua", true );
                }
            }
        }
    }
}