;; mac.el
;; ------------------------------
;; OSX specific settings

;(require 'dash)

;; Setup mackeyboard
(setq mac-option-modifier nil)
(setq mac-command-modifier 'meta)

;; Setup nice macfont
(when (eq window-system 'ns)
  (setq cccamera/default-font "-apple-Monaco-medium-normal-normal-*-14-*-*-*-m-0-iso10646-1")
  (set-face-attribute 'default nil :font cccamera/default-font))

;; Delete files to trash -- No more fuck-ups
(setq delete-by-moving-to-trash t trash-directory "~/.Trash/emacs")

(provide 'mac)
