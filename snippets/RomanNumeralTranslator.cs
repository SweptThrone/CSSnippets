using System;
using System.Text;

/*
Name:  Roman Numeral Translator
Author:  SweptThrone (sweptthr.one)
Description:  A console app that translates Arabic numerals (base 10) to Roman numerals
              also feel free to use the numToRoman method for anything else
Config:  .NET Framework 4.8, C# 7.3, compiler version 4.7.0-3.23416.8 (43b0b05c)
*/

namespace RomanNumeralTranslator {
    internal class Translator {
        // in:  integer to convert to Roman numerals
        // out:  Roman numeral as a string, or an empty string if the input is <= 0
        static string NumToRoman( int num ) {
            int[] romanNumbers = new int[ 7 ] { 1000, 500, 100, 50, 10, 5, 1 };
            char[] romanNumerals = new char[ 7 ] { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };

            StringBuilder strB = new StringBuilder();

            while ( num > 0 ) {
                for ( int i = 0; i < romanNumbers.Length; i++ ) {
                    if ( num >= romanNumbers[ i ] ) {
                        strB.Append( romanNumerals[ i ] );
                        num -= romanNumbers[ i ];

                        // if the last four chars are all the same, we're breaking the rules of Roman numerals,
                        // and we need to replace three of them with the next numeral up, however...
                        if ( strB.Length >= 4 && strB[ strB.Length - 1 ] == strB[ strB.Length - 2 ] && strB[ strB.Length - 2 ] == strB[ strB.Length - 3 ] && strB[ strB.Length - 3 ] == strB[ strB.Length - 4 ] && i - 1 >= 0 ) {
                            strB.Remove( strB.Length - 3, 3 );
                            strB.Append( romanNumerals[ i - 1 ] );

                            // ..if this results in a sandwich like VIV which is invalid,
                            // we need to replace that with the NEXT next numeral up
                            if ( strB.Length >= 3 && strB[ strB.Length - 1 ] == strB[ strB.Length - 3 ] ) {
                                char btwn = strB[ strB.Length - 2 ];

                                strB.Remove( strB.Length - 3, 3 );
                                strB.Append( btwn );
                                strB.Append( romanNumerals[ i - 2 ] );
                            }
                        }
                        break;
                    } // end if
                } // end for
            } // end while

            return strB.ToString();
        }

        static void Main( string[] args ) {
            int numberToTest = 0;

            while ( numberToTest >= 0 ) {
                Console.Write( "> " );
                if ( int.TryParse( Console.ReadLine(), out numberToTest ) ) {
                    Console.WriteLine( "= " + NumToRoman( numberToTest ) );
                } else {
                    Console.WriteLine( "= Error on input." );
                } // end if/else
            } // end while
        } // end main
    } // end class
} // end namespace
