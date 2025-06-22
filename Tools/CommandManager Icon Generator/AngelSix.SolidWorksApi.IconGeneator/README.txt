A tool to create SolidWorks toolbar icons from PNG/SVG files.

■ HOW TO USE ■

DRAG-AND-DROP METHOD:

Drag image files onto the program EXE

Choose mode when asked:
[1] ScaleImages - creates smaller versions from large images
[2] ContactBitmaps - combines multiple icons into icons sets

COMMAND LINE METHOD:
Arguments:
[images] /ScaleImages - Resizes images into indexed sets for SolidWorks
[patterns] /ContactBitmaps - Combine icons must be multi-sized images (20, 32, 40, 64, 96, 128)
/FileNamePrepend [name] - Custom name for output files (optional)

■ EXAMPLE USAGE ■
To resize a large icon:
AngelSix.SolidWorksApi.IconGeneator.exe "icon1.png" "icon2.png" /ScaleImages /FileNamePrepend "MyIconSet_"

To combine multiple icons:
AngelSix.SolidWorksApi.IconGeneator.exe "icon1_{0}.png" "icon2_{0}.png" /ContactBitmaps 

■ OUTPUT FILES ■
Program creates separate image files for each size:
Example: "icons20.png", "icons32.png", etc.
This format is used by SolidWorks API

■ NOTES ■

For best results, use SVG files

All images must be same size in ContactBitmaps mode