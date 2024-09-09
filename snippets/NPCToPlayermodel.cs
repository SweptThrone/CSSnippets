using System.Text;

/*
Name:  NPC-Playermodel Translator
Author:  SweptThrone (sweptthr.one)
Description:  A console app that finds all .qc files in a given
              directory and changes them from NPC models to
              playermodels.  This might be really gross.
              This is a DESTRUCTIVE and IRREVERSIBLE process,
              it modifies the files it finds.
Config:  .NET Framework 8.0, C# 12.0, compiler version 4.12.0-1.24379.11 (cf82d399) [?]
*/

void TranslateQCFile( string fileName ) {
    FileStream fs = File.Open( fileName, FileMode.Open, FileAccess.ReadWrite );

    byte[] fileIn = new byte[ fs.Length ];
    int n = fs.Read( fileIn, 0, ( int )fs.Length );
    string fileStr = Encoding.ASCII.GetString( fileIn ) ?? "NO BYTES FOUND";

    Console.Write( "Processing " + new DirectoryInfo( fileName ).Name + "..." );

    // remove includemodels since playermodels don't need them
    int startPos = 0;
    bool female = false;
    while ( fileStr.Contains( "$includemodel" ) ) {
        startPos = fileStr.IndexOf( "$includemodel", startPos );
        int endPos = fileStr.IndexOf( "\n", startPos );
        string findAndReplace = fileStr.Substring( startPos, endPos - startPos );

        if ( findAndReplace.ToLower().Contains( "female" ) ) {
            female = true;
        }
        fileStr = fileStr.Replace( findAndReplace, "\n" );
    }


    // insert the includemodel for playermodels, the only one that matters
    if ( female ) {
        fileStr = fileStr.Insert( startPos, "$includemodel \"f_anm.mdl\"\n" );
    } else {
        fileStr = fileStr.Insert( startPos, "$includemodel \"m_anm.mdl\"\n" );
    }

    // remove sequences except ragdoll since playermodels don't need them
    startPos = 0;
    string ragdollSequence = "";
    while ( fileStr.IndexOf( "$sequence" ) != -1 ) {
        startPos = fileStr.IndexOf( "$sequence" );
        if ( fileStr.IndexOf( "\"ragdoll\"", startPos ) == startPos + "$sequence".Length + 1 ) {
            int rdSeqStart = startPos;
            int rdSeqEnd = fileStr.IndexOf( "\n}", rdSeqStart );
            ragdollSequence = fileStr.Substring( rdSeqStart, rdSeqEnd - rdSeqStart + 3 );
        }

        int seqStartPos = fileStr.IndexOf( "$sequence" );
        int seqEndPos = fileStr.IndexOf( "\n}", seqStartPos );
        string findAndReplace = fileStr.Substring( seqStartPos, seqEndPos - seqStartPos + 3 );
        fileStr = fileStr.Replace( findAndReplace, "" );
    }

    fileStr = fileStr.Insert( startPos, ragdollSequence );

    // remove animations since playermodels don't need them
    startPos = 0;
    while ( fileStr.IndexOf( "$animation" ) != -1 ) {
        startPos = fileStr.IndexOf( "$animation" );
        int endPos = fileStr.IndexOf( "}", startPos );
        string findAndReplace = fileStr.Substring( startPos, endPos - startPos + 3 );
        fileStr = fileStr.Replace( findAndReplace, "" );
    }

    fs.Close();

    // try to clean up the holes we left
    while ( fileStr.Contains( "\r\n\r\n\r\n" ) ) {
        fileStr = fileStr.Replace( "\r\n\r\n\r\n", "\r\n" );
    }

    while ( fileStr.Contains( "\n\n\n" ) ) {
        fileStr = fileStr.Replace( "\n\n\n", "\n" );
    }

    // create a new file to overwrite
    FileStream outStream = File.Create( fileName );
    outStream.Write( Encoding.UTF8.GetBytes( fileStr ) );
    outStream.Close();

    Console.WriteLine( "done." );
}

void SearchDir( string dirName ) {
    // find all qc files
    foreach( string file in Directory.GetFiles( dirName ) ) {
        if ( file[ ^3.. ] == ".qc" ) {
            TranslateQCFile( file );
        }
    }

    // recursively search subdirectories
    foreach ( string dir in Directory.GetDirectories( dirName ) ) {
        SearchDir( dirName + @"\" + new DirectoryInfo( dir ).Name );
    }
}

// usage:
// SearchDir( @"C:\Users\SweptThrone\Desktop\gangmodels\npcout" );

void Main() {
    Console.Write( "Enter a folder path >> " );
    string folder = Console.ReadLine() ?? "quit";

    while ( folder != "quit" ) {
        SearchDir( folder );

        Console.Write( "Enter a folder path >> " );
        folder = Console.ReadLine() ?? "quit";
    }
}

Main();