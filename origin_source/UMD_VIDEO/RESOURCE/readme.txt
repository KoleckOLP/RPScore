______________________________________________________________________
¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
                               RCO Editor
                                (v1.15c)

             .:            By ZiNgA BuRgA             :.
______________________________________________________________________
¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
URL: http://endlessparadigm.com/forum/showthread.php?tid=167

 _______________
/  Introduction \
¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
  The PSP's flash contains numerous RCO files (localized resources)
in the flash0:/vsh/resource folder.  These files contain various
things such as icons, sounds, text and so on, which the PSP uses to
display the XMB interface.
  RCO Editor is what its name implies.  Currently almost all of the
RCO can be edited in RCO Editor.  Some example uses:
- replace icons
- replace sounds - support for both stereo and mono sounds
- replace text (longer text is supported)
- modify some page data

  Note, this will NOT work with RCOs in firmwares later than 2.60.
For these though, you can use Z33's Resurssiklunssi to convert them
to FW2.60 format.

 _____________
/  How to Use \
¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
  Note, using FW 2.60 or earlier RCOs on higher firmware may cause
glitches, such as icons not appearing to semi-bricking (eg using a
FW2.50 topmenu_plugin.rco on FW3.1x).

  Also note, ALWAYS keep a backup copy of the RCO, incase either you
or the program stuffs something up.  Don't forget to keep a copy of
your 3.xx RCO (assuming you're on FW3.xx) as well!

  Now, that out of the way, it's quite simple to use:
- Open your RCO file (if this is from a firmware later than FW2.60,
  you may need to use Resurssiklunssi to convert it to a usable
  format first!)

To change an icon:
- Select the General Resources tab, choose the [GIM] resource from
  the list which you want to replace, click Replace and select your
  BMP file.  Note the BMP must have a 4, 8 or 32 bit colour bit depth.

To change text:
- Select the Text Resources tab, choose the language you wish to
  edit, then the text resource from the list on the left, and
  change the text to whatever you want.

 
 Lastly, MAKE SURE YOU KNOW HOW TO USE THE RECOVERY MODE!  I'm not
 guaranteeing that this program generates valid RCOs - if you happen
 to flash an invalid RCO and it stuffs your PSP up, you really need
 to know how to recovery if such an event happens.

 _____________________________________________________________
/  FAQ (well, most of these aren't frequent, just made up :P) \
¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
Q: Where can I get information on the RCO format?
A: http://endlessparadigm.com/forum/showthread.php?tid=231

Q: Source code for RCO Editor?
A: http://endlessparadigm.com/forum/showthread.php?tid=2304

Q: How do I manually use longer text in RCO (hex editing)?
A: It's really not worth the bother.  You have to manually edit all
   the text indexes as well as shifting the text.  Just as an example
   you'll need to change about 1500+ indexes in topmenu to get longer
   text.

Q: ARGH!  Which topmenu_plugin.rco to use?!
A: I'm assuming you're on some 3.xx OE.  For 3.10, you'll need a
   special RCO.  Otherwise, for 3.00 to 3.40, you can use the same
   topmenu_plugin.rco
   Z33's Resurssiklunssi is a very useful tool to convert your 3.xx
   RCOs into formats compatible with RCO Editor.
   
Q: What does each RCO contain?
A: Well, investigate yourself!  Here's a (very short) list of common
   ones with what they're commonly used for:
    topmenu_plugin.rco             Main XMB icons and labels
	system_plugin.rco              Some XMB elements including sounds
	system_plugin_fg.rco           Battery, busy, hold etc icons
	sysconf_plugin.rco             System Config icons
	opening_plugin.rco             Coldboot/gameboot branding
	impose_plugin.rco              Volume bar; also BSoD/RSoD BG :P

 ______________
/  Limitations \
¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
  This program is written in Visual Basic... :(
Because of this, older versions of Windows (eg 9x) may not come with
the VB6 runtime files - download these from:
http://download.microsoft.com/download/5/a/d/5ad868a0-8ecd-4bb0-a882-fe53eb7ef348/VB6.0-KB290887-X86.exe

 __________
/  History \
¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
RCO Editor v1.15c (28th Oct, 2007)
- Fixed some more bugs in the GIM conversion routine


RCO Editor v1.15b (28th Oct, 2007)
- Fixed a bug in the decompression and GIM conversion routine

RCO Editor v1.15 (27th Oct, 2007)
- Rewrote GIM <-> BMP conversion routine
  - Dimension restrictions removed, as well as the "visible
    dimension" nonsense (RCO Editor automatically fixes that)
  - osk_utility.rco icons no longer cause crashes
  - Support for creating 4 bit and 32 bit GIMs (previously, only 8
    bit supported) - effectively removing the 256 colour restriction
  - You can now use ICO, PNG and GIF files as inputs, in addition to
    4 bit BMPs
- Other minor changes and bug fixes
- Added option to disable compressing resources - this is for some
  3.7x RCOs not working properly with compression enabled

RCO Editor v1.14d (3rd Jun, 2007)
- Added option to disable .bak writing
- Allow some resource adding to General and Text - note that this is
  incomplete and buggy
- Other small bug fixes

RCO Editor v1.14c (15th May, 2007)
- Fixed a bug involving image extraction

RCO Editor v1.14b (28th Apr, 2007)
- Fixed minimize crash

RCO Editor v1.14 (27th Apr, 2007)
- Minor changes/bug fixes
- Should now be fully compatible with the new decompressed 3.40 RCOs
  (note that the newer style GIMs support heights which aren't a
   multiple of 8, however, RCO Editor will require replaced images to
   have a height which is a multiple of 8 to preserve compatibility
   with older versions)

RCO Editor v1.13b (14th Apr, 2007)
- Fixed a small bug regarding replacing images of different
  dimensions

RCO Editor v1.13 (12th Apr, 2007)
- Fixed a few bugs
- Changed the way page resources are displayed
- Finally got round to updating this readme! (lol I'm lazy >_>)

RCO Editor v1.12b (12th Mar, 2007)
- Fixed the stupid bug which caused the app to crash when editing text

RCO Editor v1.12 (11th Mar, 2007)
- Fixed more bugs
- Added a text search function
- There's now an "expert" mode (launch RCOEdit with the 'expert'
  command-line switch or edit the INI).
  This gives a few more options:
   > Access to Page/Anim resources - I'm not sure how these are
     exactly structured, but they are somewhat editable
   > Can change the visible dimensions on MIG resources
   > "Random Info" button just displays some, erm, random info

RCO Editor v1.11 (3rd Mar, 2007)
- Fixed yet some more bugs, lol.
- Added a Replace Multiple resources function (for MIG/VAG/OMG
  resources)
- Many bugs fixed with VAG replacing
- Now handles multiple channel (stereo) VAGs properly - you can also
  make stereo sounds too :)

RCO Editor v1.10 (28th Feb, 2007)
- Fixed a few bugs
- Other slight changes
- Support for editing text - note that you can also use _longer_ text
  than the original!
- Name change
- Padding is now disabled as it seems to have no effect any more :)
  
RCO Icon Editor v1.07 (22th Feb, 2007)
- Fixed various things
  > now should generate more "standard" RCOs
  > now should be able to extract a few more icons (note, the program
    doesn't recreate the icon exactly as it was before, so I'm not
	sure if replacing some icons will break the file or not :S)
- Added support for FW2.60 RCOs

RCO Icon Editor v1.06 (19th Feb, 2007)
- Added support for PNG resources
- Fixed a few bugs - should also recognise a few more resources (4bit
  MIG support is yet to be done)

RCO Icon Editor v1.05 (15th Feb, 2007)
- Added an Extract All function
- Will now automatically backup the RCO before editing (makes a .bak
  file)
- Bug fix (was causing issues when loading some custom
  system_plugin_bg.rco files)

RCO Icon Editor v1.04 (14th Feb, 2007)
- A simple hack to make RCOs containing multiple VAGs to be recognised
  correctly
- Minor bugs with the Preview window fixed

RCO Icon Editor v1.03 (14th Feb, 2007)
- Added a Preview window
- Labels should now be correct
- Writes more "standard" RCOs, thanks to Z33's excellent documentation

RCO Icon Editor v1.02 (14th Feb, 2007)
- Added an option to make the colour of the first pixel transparent

RCO Icon Editor v1.01 (13th Feb, 2007)
- Fixes some bugs :)

RCO Icon Editor v1.0 (12th Feb, 2007)
- Fixes some offsets - increases chances of customized RCOs working
  without padding (testing with an opening_plugin.rco, the bootsound
  now works, but the animation is still stuffed :|)
- Can now handle OMG and VAG resources (for VAG, that means you can
  now use bootsounds larger than ~197KB!!!)
  
RCO Icon Editor beta (11th Feb, 2007)
- Added the ability to replace icons
- Fixed some bugs in alpha 2

RCO Icon Editor alpha 2 (10th Feb, 2007)
- Added the ability to extract icons as a MIG, or BMP (8 or 32 bit)
- Added a Preview function

RCO Icon Editor alpha (9th Feb, 2007)
- First Release :)

 __________
/  Credits \
¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
- LaVolpe for his 32bit BMP render for VB6.  This can be found at:
  http://www.planet-source-code.com/vb/scripts/ShowCode.asp?txtCodeId=67466&lngWId=1

- Z33 - he managed to discover a lot more than I did about the RCO
  format - excellent work!
  
- Also, everyone involved with the XMB icon editing - your discovery
  helped me in figuring out how everything works :)
  
 _____________
/  Disclaimer \
¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
Oh, man, do I _have_ to write this?
By using this program, I am NOT responsible for any damage, loss
of fun etc that this program may cause.

Also, you may distribute this program in any way, as long as
it's in its original, unmodified package (ie with this readme), and
it remains free.
