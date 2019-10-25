#Author: Ethan Kamus
#email: ethanjpkamus@csu.fullerton.edu

rm *.dll
rm *.exe

echo View the list of source files
ls -l

echo "Compile ricochetballuserinterface.cs:"
mcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -out:ricochetballuserinterface.dll ricochetballuserinterface.cs

echo "Compile and link ricochetballmain.cs:"
mcs -r:System -r:System.Windows.Forms -r:ricochetballuserinterface.dll -out:ricochetball.exe ricochetballmain.cs

echo "Run the program Ricochet Ball"
./ricochetball.exe

echo "The bash script has terminated."
