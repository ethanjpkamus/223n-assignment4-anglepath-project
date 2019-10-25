//Author: Ethan Kamus
//Email: ethanjpkamus@csu.fullerton.edu

//Purpose: to animate a "ball" moving across a straight path at a user input angle

using System;
using System.Windows.Forms;

public class ricochetballmain{

     static void Main(string[] args){

          System.Console.WriteLine("Welcome to the Main method of the Ricochet Ball program.");
          ricochetballuserinterface application = new ricochetballuserinterface();
          Application.Run(application);
          System.Console.WriteLine("Main method will now shutdown.");

     }//End of Main

}//End of redlightmain
