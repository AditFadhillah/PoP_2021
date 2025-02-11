;;; fsharp.el --- Description -*- lexical-binding: t; -*-
;;; Code:

; You might need to set the path to F#, respectively fsharpi and fsharpc
;; F# of course needs to be installed first
;; If you are on Windows and installed mono, this is most probably the correct path.
;; Uncomment to set it on launch
;; (setq inferior-fsharp-program "\"C:\\Program Files\\Mono\\bin\\fsharpi\"")

;; On a mac, this is most probably the correct paths. Uncomment to set it
;; (setq inferior-fsharp-program "/Library/Frameworks/Mono.framework/Versions/Current/Commands/fsharpi --readline-")
;; (setq fsharp-compiler "/Library/Frameworks/Mono.framework/Versions/Current/Commands/fsharpc")

;; On linux, the installation dir depends on your distribution
;; Run the command "which fsharpi" in a terminal to get the correct path
;; (setq inferior-fsharp-program "INSERT/PATH/HERE/fsharpi")

(provide 'fsharp)
;;; fsharp.el ends here
