using System;
using System.IO;

/*
Name:  Access Log Parser
Author:  SweptThrone (sweptthr.one)
Description:  A console app that parses access logs for my website.
              This was made to see how many people are falling for
              my fake cheat video I uploaded to my YouTube channel,
              and has little to no use outside of that.
Config:  .NET Framework 4.8, C# 7.3, compiler version 4.7.0-3.23416.8 (43b0b05c)
*/

namespace AccessLogParser {
    internal class AccessLogParser {
        // in:  path to file to parse
        // out:  null, creates a file named ".cheatwanters" which is a newline-separated file of IP addresses
        //       this is so i can count the visits easier, since that's all i care about
        static void Main( string[] args ) {
            string line;
            string lineOut;
            string fileName;

            if ( args.Length == 0 ) {
                Console.Write( "Enter access log file name > " );
                fileName = Console.ReadLine();
            } else {
                fileName = args[ 0 ];
            }

            StreamReader reader = new StreamReader( fileName );
            StreamWriter writer = new StreamWriter( ".cheatwanters" );
            line = reader.ReadLine();

            while ( line != null ) {
                if ( line.IndexOf( "\"GET /cheat/download HTTP/1.1\" 301 795 \"https://www.youtube.com/\"" ) != -1 ) {
                    // output IP address
                    // it's easy since it's the first string in each log line,
                    // and i can see if one person visited multiple times
                    lineOut = line.Substring( 0, line.IndexOf( " - - " ) );
                    writer.WriteLine( lineOut );
                }
                writer.Flush();
                line = reader.ReadLine();
            }

            // open the file as soon as it's created
            System.Diagnostics.Process.Start( ".cheatwanters" );
        }
    }
}
