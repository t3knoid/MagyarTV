;NSIS Modern User Interface
;Basic Example Script
;Written by Joost Verburg

;--------------------------------
;Include Modern UI

    !include "MUI2.nsh"
    !include "x64.nsh"

;--------------------------------
;General

    ;Name and file
    Name "MagyarTV"
    OutFile "MagyarTV_Installer.exe"

    ;Default installation folder
    InstallDir "$PROGRAMFILES64\MagyarTV"
  
    ;Get installation folder from registry if available
    InstallDirRegKey HKCU "Software\MagyarTV" ""

    ;Request application privileges for Windows Vista
    RequestExecutionLevel admin

;--------------------------------
;Interface Settings

    !define MUI_ABORTWARNING
    !define MUI_PAGE_HEADER_TEXT "$(^Name) Setup"
    !define MUI_INSTFILESPAGE_FINISHHEADER_TEXT "$(^Name) Installed"
    !define MUI_FINISHPAGE_RUN "$INSTDIR\MagyarTV.exe"
    !define MUI_FINISHPAGE_RUN_TEXT "Launch $(^Name)"
    !define MUI_FINISHPAGE_TITLE "Setup Complete"
    !define MUI_FINISHPAGE_TEXT "$(^Name) is now installed. Click Close to complete setup."
    !define MUI_FINISHPAGE_BUTTON "Close"
    !define MUI_UNCONFIRMPAGE_TEXT_TOP "Uninstalling $(^Name)"
    !define MUI_UNCONFIRMPAGE_TEXT_LOCATION "Uninstalling $(^Name)"

;--------------------------------
;Pages

    !insertmacro MUI_PAGE_DIRECTORY
    !insertmacro MUI_PAGE_INSTFILES
    !insertmacro MUI_PAGE_FINISH

    !insertmacro MUI_UNPAGE_CONFIRM
    !insertmacro MUI_UNPAGE_INSTFILES
  
;--------------------------------
;Languages
 
    !insertmacro MUI_LANGUAGE "English"

;--------------------------------
;Functions

; Create the shared function.
!macro MYMACRO un
    Function ${un}killapp
        StrCpy $0 "MagyarTV.exe"
        DetailPrint "Searching for processes called '$0'"
        KillProc::FindProcesses
        StrCmp $1 "-1" wooops
        DetailPrint "-> Found $0 processes"
        StrCmp $0 "0" completed
        Sleep 1500
        StrCpy $0 "MagyarTV.exe"
        DetailPrint "Killing all processes called '$0'"
        KillProc::KillProcesses
        StrCmp $1 "-1" wooops
        DetailPrint "-> Killed $0 processes, failed to kill $1 processes"
        Sleep 1500
        Goto completed
    wooops:
        DetailPrint "-> Error: Something went wrong :-("
        Abort
    completed:
        DetailPrint "Everything went okay :-D"
    FunctionEnd
!macroend

Function .onInit
    DetailPrint "Checking if $(^Name) is installed."
	ReadRegStr $R0 HKLM "SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" "UninstallString"
	DetailPrint "Uninstall string read is $R0"
	StrCmp $R0 "" NotInstalled
	MessageBox MB_YESNO|MB_TOPMOST "$(^Name) is already installed. Uninstall?" IDYES Yes IDNO No
	No:
		DetailPrint "$(^Name) is installed. Quitting install."
		Quit
	Yes:
		DetailPrint "Uninstalling $(^Name)."
		ExecWait $R0
 	NotInstalled:
	DetailPrint "$(^Name) not installed. Continuing with installation."
	# start install
FunctionEnd

; Insert function as an installer and uninstaller function.
!insertmacro MYMACRO ""
!insertmacro MYMACRO "un."

;--------------------------------
;Installer Sections

Section "MagyarTV" MagyarTV
    # start install
	call killapp
    
    SetOutPath "$INSTDIR"
    File /r "..\MagyarTV\bin\x64\Release\*.*"
  
    ;Store installation folder
    WriteRegStr HKCU "Software\MagyarTV" "" $INSTDIR
    
    ;Add/Remove entry
	# Add add/remove entry
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" \
		"DisplayName" "$(^Name)"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" \
		"UninstallString" "$\"$INSTDIR\uninstall.exe$\""
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" \
		"DisplayIcon" "$\"$INSTDIR\MagyarTV.exe$\""	  
    ;Create uninstaller
    WriteUninstaller "$INSTDIR\Uninstall.exe"

SectionEnd

;--------------------------------
;Start Menu shortcuts

Section "Start Menu Shortcuts"

	CreateDirectory "$SMPROGRAMS\MagyarTV"
	CreateShortCut "$SMPROGRAMS\MagyarTV\MagyarTV.lnk" "$INSTDIR\MagyarTV.exe"
    CreateShortCut "$SMPROGRAMS\MagyarTV\Uninstall.lnk" "$INSTDIR\uninstall.exe"
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
    
    call un.killapp
    # remove the link from the start menu
	Delete "$SMPROGRAMS\\Uninstall.lnk"
    Delete "$SMPROGRAMS\MagyarTV\MagyarTV.lnk"
	RMDir "$SMPROGRAMS\MagyarTV"
    
    Delete "$INSTDIR\Uninstall.exe"
    
    # delete installation folder        
    RMDir /r "$INSTDIR"
    
    DeleteRegKey /ifempty HKCU "Software\MagyarTV"
        
    # Remove add/remove registry entry
    DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\MagyarTV"

SectionEnd