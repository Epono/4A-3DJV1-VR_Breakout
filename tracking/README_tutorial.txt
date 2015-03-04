Tutorial "Adaptive rendering for Virtual Reality": installation and general instructions
ESGI - January 2015

1- Installation (Windows):
---------------

The tutorial is organized as two sessions:

session 1: 3d tracking with colored markers : Python script associated named tracking.py
session 2: 3d rendering with variable frustum (computed from 3d tracking) : Unity project called adaptive_test

Currently the tracking script is for PYTHON 2.7 (will NOT work with Python 3.x), 32bits version.
DO NOT try with 64bits version. 32bits version will work on 32 and 64bits computers.

a) Install Python 2.7 , 32bits version (the repository should contain python-2.7.msi). 
b) Install numpy 1.8 (numerical library for Python), 32bits also. The repository contains
numpy-MKL-1.8.0.win32-py2.7.exe
c) Install OpenCV (open source image processing library), current version on opencv.org
is 2.4. The repository should contain OpenCV-2.4.7.exe, a self-installing archive. Beware,
installation is lengthy.
We'll use the python interface, located in %OPENCV_INSTALL%\build\python\2.7\x86, 
named cv2.pyd . Copy this file in 
C:\Python27\Lib\site-packages (or wherever your Python installation is).
d) Install PyOpenGL (python bindings for OpenGL), 3.x, included in repository.
e) Install PIL (python image library). Current is 1.1.7, included in repository.
f) If you haven't done it already, install Glut32 (win32 bits), from Nate Robbin's site. GLUT is
the basic interface to access OpenGL library. The
zip is in the repository. Use the lib and dll, and put them in c:\Windows\System32 and c:\Windows\SysWoW64.

Session 1 also uses liblo, a communication library, with two files included in the tutorial
archive: liblo.pyd (python binary) and liblo.dll. Keep these whereever you start you python scripts.

Finally, we need the POSIX threads library implementation for Windows, named pthreadVC2.dll, also
included in the archive.

2- running
-----------

You should have a Webcam attached to your computer. If the tracking script tracking.py does not start, it may be 
because the call cv.CaptureFromCAM() does not find proper device. Try and adjust until camera capture works.

a) open a console, go to the (unzipped) archive location
b) TRACKING TUTORIAL: run c:\python27\python.exe tracking.py glasses.txt
c) RENDERING TUTORIAL: go to Unity project directory, start adaptive_test.unity file.

Detailed instructions on the tutorials are found in the attached pdf files:

texte_tutorial_stereo_adaptive.pdf (tracking part)
texte_tutorial_stereo_rendering.pdf (rendering part)








