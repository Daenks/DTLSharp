# DTLSharp
## Description
DTLSharp is a C# library for [Dundeon Template Library](https://github.com/AsPJT/DungeonTemplateLibrary/).

The code for this library is modified from the [DTLUnity](https://github.com/sitRyo/DungeonTemplateLibraryUnity) project. What I've done here is removed all the references and dependencies on Unity so that DTL can be used in any .NET environment.

I have so far only tested this under .NET 6.0

Example Usage:

```C#
int size_x = 512;
int size_y = 512;
int[,] matrix = new int[size_x, size_y];

double frequency = 5.0f;
uint octaves = 7;
int maxHeight = 200;
int minHeight = 200;

new DTL.Shape.PerlinIsland(frequency: frequency, octaves, maxHeight, minHeight).Draw(matrix);
```

Please see the original project wikis for more in-depth documentation.