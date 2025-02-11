;; keybindings.el
;; ------------------------------
;; File that sets up my custom keybindings for emacs
;;

;; switch to last used buffer
(global-set-key (kbd "C-x p") 'switch-to-last-buffer)

;; Open previous buffer on right or below
(global-set-key (kbd "C-x 2") 'open-prev-buffer-below)
(global-set-key (kbd "C-x 3") 'open-prev-buffer-on-right)

;; Open shell on right or below
(global-set-key (kbd "C-c C-x 2") 'open-shell-below)
(global-set-key (kbd "C-c C-x 3") 'open-shell-on-right)


;; Setup rotate windows
;; Enables to switch buffers around when they open in the wrong place
(global-set-key (kbd "C-c C-r") 'rotate-windows)

;; Create newlines mid-sentence both above and below
(global-set-key (kbd "<C-return>") 'open-line-below)
(global-set-key (kbd "<C-M-return>") 'open-line-above)

;; Scroll other buffer upwards
(global-set-key (kbd "C-M-f")  (lambda () (interactive) (scroll-other-window -36)))


;; make ibuffer default for buffer change
(global-set-key (kbd "C-x C-b") 'ibuffer)

;; change search and search regexp
;; A string is a regexp, so unless you are searching for a regex that emacs
;; can interpret, this has no bad effects.
(global-set-key (kbd "C-s") 'isearch-forward-regexp)
(global-set-key (kbd "C-r") 'isearch-backward-regexp)
(global-set-key (kbd "C-M-s") 'isearch-forward)
(global-set-key (kbd "C-M-r") 'isearch-backward)

;; Switch buffer with C-TAB, just like in a browser
(global-set-key (kbd "C-<tab>") 'other-window)
(global-set-key (kbd "C-<iso-lefttab>") (other-window 1))

;; Yank-on-right
;; ------------------------------
;; Insert copied lines on the right of region
;; Handy for editing matrices/arrays and such
(global-set-key (kbd "C-c C-.") 'yank-on-right)


;; Kill other buffers
;; ------------------------------
;; Not using this anymore. Lowercase region is much more used.
;;(global-set-key (kbd "C-x C-l") 'kill-other-buffers)



;; smex - Smart M-x
;; This will enable auto-completion and fuzzy match suggestions
;; for emacs-commands
(global-set-key (kbd "M-x") 'smex)

;; kills current buffer and deletes file
;; ------------------------------
;; Commented out, because deleting files when you don't mean to is a bad time
;;(global-set-key (kbd "C-x C-k") 'delete-current-buffer-file)


;; Ace-jump mode - jump to char by char
;; Press C-f, enter a letter, and press the key indicating where you want to jump to
(global-set-key (kbd "C-f") 'ace-jump-mode)


;; Joins the current line and the line below at cursor
;; Very easy way of deleting newlines and thus joining lines!
(global-set-key (kbd "M-j")
		(lambda ()
		  (interactive)
                  (join-line -1)))


;; Move lines up and down
(global-set-key (kbd "<M-up>") 'move-line-up)
(global-set-key (kbd "<M-down>") 'move-line-down)

;; Handy if writing elisp, not handy for much else
(global-set-key (kbd "C-c C-e") 'replace-last-sexp)


;; Setup multiple cursors
;; ------------------------------
;; Multiple cursors is hard to learn and impossible to live without when learned
(global-set-key (kbd "C-<") 'mc/mark-next-like-this)
(global-set-key (kbd "C->") 'mc/mark-previous-like-this)
(global-set-key (kbd "C-c C-<") 'mc/mark-all-like-this)
(global-set-key (kbd "C-c C-c C-<") 'mc/mark-all-in-region)
(provide 'keybindings)
;;; keybindings.el ends here
