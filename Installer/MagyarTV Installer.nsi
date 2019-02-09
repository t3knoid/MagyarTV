;NSIS Modern User Interface
;Basic Example Script
;Written by Joost Verburg

;--------------------------------
;Include Modern UI

    !include "MUI2.nsh"

;--------------------------------
;General

    ;Name and file
    Name "MagyarTV"
    OutFile "MagyarTV_Installer.exe"

    ;Default installation folder
    InstallDir "$LOCALAPPDATA\MagyarTV"
  
    ;Get installation folder from registry if available
    InstallDirRegKey HKCU "Software\MagyarTV" ""

    ;Request application privileges for Windows Vista
    RequestExecutionLevel user

;--------------------------------
;Interface Settings

    !define MUI_ABORTWARNING

;--------------------------------
;Pages

    !insertmacro MUI_PAGE_DIRECTORY
    !insertmacro MUI_PAGE_INSTFILES
  
    !insertmacro MUI_UNPAGE_CONFIRM
    !insertmacro MUI_UNPAGE_INSTFILES
  
;--------------------------------
;Languages
 
    !insertmacro MUI_LANGUAGE "English"

;--------------------------------
;Installer Sections

Section "MagyarTV" MagyarTV
    SetOutPath "$INSTDIR"
    File /r "..\MagyarTV\bin\x64\Release\*.*"
  
    ; Shortcut
    CreateDirectory "$SMPROGRAMS\MagyarTV"
    CreateShortcut "$SMPROGRAMS\MagyarTV\MagyarTV.lnk" "$INSTDIR\MagyarTV.exe" "$INSTDIR\MagyarTV.exe" SW_SHOWNORMAL
    
    ;Store installation folder
    WriteRegStr HKCU "Software\MagyarTV" "" $INSTDIR
    
    ;Add/Remove entry
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\MagyarTV" "DisplayName" "MagyarTV"
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\MagyarTV" "QuietUninstallString" "$\"$INSTDIR\uninstall.exe$\" /S"
  
    ;Create uninstaller
    WriteUninstaller "$INSTDIR\Uninstall.exe"

SectionEnd

;--------------------------------
;Descriptions

    ;Language strings
    LangString DESC_SecDummy ${LANG_ENGLISH} "A test section."

    ;Assign language strings to sections
    !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
    !insertmacro MUI_DESCRIPTION_TEXT ${SecDummy} $(DESC_SecDummy)
    !insertmacro MUI_FUNCTION_DESCRIPTION_END

;--------------------------------
;Uninstaller Section

    Section "Uninstall"
    Delete "$INSTDIR\Uninstall.exe"
    RMDir /r "$INSTDIR"
    RMDIR /r "$SMPROGRAMS\MagyarTV"
    DeleteRegKey /ifempty HKCU "Software\MagyarTV"
    DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\MagyarTV"

SectionEnd