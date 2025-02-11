;; init.el
;; ------------------------------
;; Author: Mads Obitsø, Jacob Herbst
;; contains lots and lots of copied code from the big ol' internet

;; Turn off mouse interface early in startup to avoid momentary display
;; If you uncomment these lines, all the \"clickable things\" will be disabled
;; (if (fboundp 'menu-bar-mode) (menu-bar-mode -1))
;; (if (fboundp 'tool-bar-mode) (tool-bar-mode -1))
;; (if (fboundp 'scroll-bar-mode) (scroll-bar-mode -1))

;; Disable the splash screen
(setq inhibit-startup-message t)

;; Ask before killing emacs
(setq confirm-kill-emacs 'y-or-n-p)

;; Waste of bytes
(setq initial-scratch-message
";; Welcome to Emacs! You are running the configuration supplied by the PoP 2021 team.
;;
;; This should setup fsharp-mode with syntax-highlighting and interactive evaluation of expressions and buffers
;; As well as a simple LaTeX mode, to make it a bit nicer for you to write your reports
;;
;; Emacs is admittedly a bit hard to learn - especially if you have never used a programmable text-editor before.
;; We promise you that it is well worth the effort. If you end up hating emacs, we recommend that you try out ViM (or kakoune).
;; Ask your fellow students what editor they use and why. Most people at DIKU have an editor they swear by for good reasons.
;;
;; A small cheat-sheet for using emacs:
;; KEYBINDINGS:
;; Emacs is all about hotkeys. In fact, everything you can do in emacs,
;; can be bound to a key. Emacs-key-commands have the following syntax:
;; C-x     = Hold down the CTRL key and press x. Most emacs-commands start this way
;; C-x C-s = Hold down the CTRL key and press x. Keep holding CTRL and press s
;; M-w     = Hold down the META key and press w. META is the alt-key on windows/linux and the CMD key on a mac (with the PoP setup)
;;
;; A FEW NICE TO KNOW KEYBINDINGS:
;; (This might seem like a lot. Don't try to remember them all at once!)
;; C-x C-s = Save the current file
;; C-x C-f = open a file. You will have to write the path in the minibuffer and press enter. Try pressing TAB to autocomplete!
;; M-w     = Copy the current selection
;; C-w     = Cut the current selection
;; C-y     = Paste the current selection. (In emacs, this is called \"yank\")
;; C-x p   = Switch to the previously opened buffer
;; C-x o   = If emacs has multiple windows open, move the cursor to the next one
;; C-s     = Search for a word. Press it once to open a prompt and enter your search term. Press it again to jump to the next occurrence
;; C-r     = Search for a word \"backwards\". If you jump too far when searching with C-s, you can go back with C-r
;; C-x C-v = Exit emacs.
;; C-x k   = Kill buffer. Killing a buffer in emacs is the same as closing a file in word. (Emacs can have many files/buffers open at the same time)
;; C-x b   = switch to a different buffer
;; C-x C-b = Switch to a different buffer, from a list of all your open buffers
;; C-k     = Kill the current line (Delete from the cursor to the end
;; C-a     = Move the cursor to the beginning of the line
;; C-e     = Move the cursor to the end of the line
;; C-SPACE = Start selection (You can also hold down SHIFT and move the cursor)
;; C-x 3   = Split the current window in two on the vertical axis (opens a new window on the right)
;; C-x 2   = Split the current window in two on the horizontal axis (Opens a new window below)
;; C-v     = Similar to PageDown. Move the cursor down \"one page\"
;; M-v     = Similar to PageUp. Move the cursor Up \"one page\"
;; M-x     = run an emacs-command. (We have replaced this with a nicer version)
;; C-h t   = Run the built-in emacs tutorial
;; C-h k   = \"describe key\". Press this, then a key-combination you don't know what does. Emacs will tell you.
;;           for instance, try pressing `C-h k C-x C-s`  -  Emacs should tell you it will save the current buffer to a file
;; My favorites are:
;; C-:     = waits for you to write a character,
;;           it then marks occurences of that char and by pressing
;;           the charather combination for this the cursor jumps
;;           to that position
;; C-'     = Same as above but you input 2 characters
;; M-g l   = Same as above, but will not ask you for anything, but you
;;           can jump to the line you wants.
;; M-g w   = takes a char and goes to a word starting with that char
;;
;; WHICH-KEY
;; this is an extension that will show all the possible commands given
;; a keybinding. try C-x and you can see a lot of functions you can try.
;;Whenever you do a command a you want to quit it do C-g
;;
;; TREEMACS is very nice to get an overview of your files
;; M-0    = Will switch to treemacs. you can rightclick stuff in treemacs
;; if you are not too comfortable with the keybindings yet.
;;
;; FSHARP-MODE
;; In PoP we write a ton of F#
;; fsharp-mode enables us to run fsharpi inside emacs, and use it to
;; interactively evaluate F#, either expression by expression, a selected region or even a whole buffer at a time!
;; First, you need to do a small amount of setup.
;;
;; Open the file ~/.emacs.d/my-setup/fsharp.el
;; Try doing it with your new keystroke-skills: `C-x C-f ~/.emacs.d/my-setup/fsharp.el RET`
;; In the bottom of that file, you will need to set the path to fsharpi, so emacs can find it.
;; Follow the instructions in the file or ask a TA if all goes wrong.
;;
;; Now try opening an fsharp-file (with .fsx suffix).
;; Write an expression, e.g. `let pop = \"fsharp in emacs, woohoo!\"`
;; Now put the cursor at the end of that line, and press `C-x C-e` (e for evaluate)
;; Emacs should prompt you to run an \"inferior fsharp program\". Press RET
;; Now, emacs should split the window in 2, and you will have fsharpi running inside emacs
;; The window should evaluate the expression from your fsharp-file and print the result.
;;
;; FSHARPI KEYBINDINGS
;; C-x C-e  = Evaluate the current line
;; C-x C-r  = Evaluate the current region
;;
;; SOME EMACS TERMINOLOGY
;; The first versions of emacs came in the '70s, a time long lost when most computers didn't even have a display (but a printer).
;; Windows, GUI's and mice were not invented, so emacs uses some terminology that might be confusing in 2020.
;; Frame = In emacs, what we call \"a window\", is called a \"frame\"
;; Window = A frame can have multiple windows.
;; Buffer = In emacs, everything is a buffer. A buffer *can* be a file, but doesn't have to be.
;;          for example, *scratch* is the buffer you are looking at, and it is not associated with a file.
;; C      = Usually means the control key
;; M      = Usually means the META key. Old keyboards had a physical META key. Today it is usually the ALT key.
;; Init-file = The file (or files!) that set up emacs. This setup uses multiple files
;;
;; INIT FILES, Elisp and What even is a programmable editor
;; Read this section if you think emacs is interesting and want to know more.
;; In emacs, we can write elisp to configure emacs, (even as it is running).
;; When emacs starts, it will look for an init-file in some predefined locations, read in the file and reconfigure itself!
;; Now, what is an init-file you think? It is a program, written in elisp.
;; elisp is a programming language in the LISP-family (emacs-lisp).
;; elisp is not part of the PoP-curriculum and we do not expect you to understand, or even attempt to understand, elisp.
;; However, having a programmable editor does have a lot of benefits.
;; In emacs everything you can do can be defined as a function in elisp.
;; Saving a file is a function, heck, even moving the cursor with the arrow-keys or typing a letter is a function!
;; You can always press `C-h k` and then enter a key or key-combination to see what function is called.
;; pressing the right-arrow-key will call the elisp-function right-char
;; pressing the a-key will run the elisp-function self-insert-command (that inserts the character into the current buffer)
;; Because \"everything is a function\", and the fact that we can evaluate elisp-expressions while emacs is running,
;; we can make emacs do whatever we want to (as long as we can write the elisp of course).
;; Some of the functions used in this setup, have been customly defined. You can see them in ~/.emacs.d/my-setup/my-functions.el
;; For example, when you press `C-x p`, emacs will call the custom function `switch-to-last-buffer`
;;
;; EMACS GAMES
;; Emacs even comes with built-in games.
;; Try pressing ‘M-x tetris‘ and forget all about F# for a moment.
;; If you need to tell someone that PoP and DMA is hard, you can try the built-in psychiatrist:
;; M-x doctor
;;
;;
;; WELCOME POP-student!
;; This is the end of our \"short introduction to emacs\";;
;; Go to the top of this buffer by scrolling - or by pressing one of the following:
;; Up-arrow (a looot of times)
;; M-< (ALT-key and <) or (CMD and < if you are using a mac)
;; `M-v` a bunch of times (ALT-key and v/CMD-key and v)
;; or by evaluating this elisp-expression with C-x C-e. Try it!
(beginning-of-buffer)
;;
;; If you want to change your color-theme checkup the possibilities here:
;; https://github.com/hlissner/emacs-doom-themes/tree/screenshots
;; Once you have decided on one goto your ~/.emacs.d/my/setup/theme.el file and
;; replace 'doom-one with your theme
;; For instance 'doom-nord (notice the apostrophy) and save the file.
")

;; Go straight to *scratch* buffer on startup
(setq initial-buffer-choice t)

;; Set path to dependencies
(setq site-lisp-dir
      (expand-file-name "site-lisp" user-emacs-directory))

(setq my-setup-lisp
      (expand-file-name "my-setup" user-emacs-directory))

;; Set up load-path
(add-to-list 'load-path my-setup-lisp)
(add-to-list 'load-path site-lisp-dir)
;; Make site-lisp-dir the package folder
;; This is where installed packages will end up
(setq package-user-dir "~/.emacs.d/site-lisp")

(set-fringe-mode 10)        ; Give some breathing room
(scroll-bar-mode -1)        ; Disable visible scrollbar
(tooltip-mode -1)           ; Disable tooltips
(setq visible-bell t)

(load-theme 'tango-dark)

; Make ESC quit prompts
(global-set-key (kbd "<escape>") 'keyboard-escape-quit)

;; Initialize package sources
(require 'package)

(setq package-archives '(("melpa" . "http://melpa.org/packages/")
                         ("elpa" . "http://elpa.gnu.org/packages/")))

(package-initialize)
(unless package-archive-contents
 (package-refresh-contents))

;; Initialize use-package on non-Linux platforms
(unless (package-installed-p 'use-package)
   (package-install 'use-package))

(require 'use-package)
(setq use-package-always-ensure t)

(use-package vertico
  :ensure t
  :bind (:map vertico-map
         ("C-j" . vertico-next)
         ("C-k" . vertico-previous)
         ("C-f" . vertico-exit)
         ("?"   . minibuffer-completion-help)
         ("M-RET" . minibuffer-force-complete-and-exit)
         ("TAB" . minibuffer-complete)
         )
;;   (define-key vertico-map "?" #'minibuffer-completion-help)
;; (define-key vertico-map (kbd "M-RET") #'minibuffer-force-complete-and-exit)
;; (define-key vertico-map (kbd "M-TAB") #'minibuffer-complete)
  :custom
  (vertico-cycle t)
  :init
  (vertico-mode))

(use-package savehist
  :init
  (savehist-mode))

(use-package marginalia
  :after vertico
  :ensure t
  :custom
  (marginalia-annotators '(marginalia-annotators-heavy marginalia-annotators-light nil))
  :init
  (marginalia-mode))

(use-package doom-modeline
  :ensure t
  :init (doom-modeline-mode 1)
  :custom ((doom-modeline-height 15)))

(column-number-mode)
(global-display-line-numbers-mode t)

;; Disable line numbers for some modes
(dolist (mode '(org-mode-hook
                term-mode-hook
                eshell-mode-hook))
  (add-hook mode (lambda () (display-line-numbers-mode 0))))

(use-package which-key
  :init (which-key-mode)
  :diminish which-key-mode
  :config
  (setq which-key-idle-delay 0))

(use-package rainbow-delimiters
  :hook (prog-mode . rainbow-delimiters-mode))

(use-package yasnippet
  :bind
  ("C-c y s" . yas-insert-snippet)
  ("C-c y v" . yas-visit-snippet-file)
  :config
  (add-to-list 'yas-snippet-dirs "~/.emacs.d/snippets")
  (yas-global-mode 1))

(use-package highlight-indent-guides
  :hook (prog-mode . highlight-indent-guides-mode))

(use-package highlight-numbers
  :hook (prog-mode . highlight-numbers-mode))

(use-package fsharp-mode
  :defer t
  :ensure t)
(setq fsharp-doc-idle-delay 0)
(setq fsharp-ac-intellisense-enabled t)
(require 'fsharp)

(use-package avy
  :diminish
  :bind (("C-:" . avy-goto-char)
         ("C-'" . avy-goto-char-2)
         ("M-g l" . avy-goto-line)
         ("M-g w" . avy-goto-word-1)
         ))

(use-package tex
  :ensure auctex)


(use-package treemacs
  :ensure t
  :defer t
  :init
  (with-eval-after-load 'winum
    (define-key winum-keymap (kbd "M-0") #'treemacs-select-window))
  :config
  (progn
    (setq treemacs-collapse-dirs                   (if treemacs-python-executable 3 0)
          treemacs-deferred-git-apply-delay        0.5
          treemacs-directory-name-transformer      #'identity
          treemacs-display-in-side-window          t
          treemacs-eldoc-display                   t
          treemacs-file-event-delay                5000
          treemacs-file-extension-regex            treemacs-last-period-regex-value
          treemacs-file-follow-delay               0.2
          treemacs-file-name-transformer           #'identity
          treemacs-follow-after-init               t
          treemacs-expand-after-init               t
          treemacs-git-command-pipe                ""
          treemacs-goto-tag-strategy               'refetch-index
          treemacs-indentation                     2
          treemacs-indentation-string              " "
          treemacs-is-never-other-window           nil
          treemacs-max-git-entries                 5000
          treemacs-missing-project-action          'ask
          treemacs-move-forward-on-expand          nil
          treemacs-no-png-images                   nil
          treemacs-no-delete-other-windows         t
          treemacs-project-follow-cleanup          nil
          treemacs-persist-file                    (expand-file-name ".cache/treemacs-persist" user-emacs-directory)
          treemacs-position                        'left
          treemacs-read-string-input               'from-child-frame
          treemacs-recenter-distance               0.1
          treemacs-recenter-after-file-follow      nil
          treemacs-recenter-after-tag-follow       nil
          treemacs-recenter-after-project-jump     'always
          treemacs-recenter-after-project-expand   'on-distance
          treemacs-litter-directories              '("/node_modules" "/.venv" "/.cask")
          treemacs-show-cursor                     nil
          treemacs-show-hidden-files               t
          treemacs-silent-filewatch                nil
          treemacs-silent-refresh                  nil
          treemacs-sorting                         'alphabetic-asc
          treemacs-select-when-already-in-treemacs 'move-back
          treemacs-space-between-root-nodes        t
          treemacs-tag-follow-cleanup              t
          treemacs-tag-follow-delay                1.5
          treemacs-text-scale                      nil
          treemacs-user-mode-line-format           nil
          treemacs-user-header-line-format         nil
          treemacs-width                           35
          treemacs-width-is-initially-locked       t
          treemacs-workspace-switch-cleanup        nil)

    ;; The default width and height of the icons is 22 pixels. If you are
    ;; using a Hi-DPI display, uncomment this to double the icon size.
    ;;(treemacs-resize-icons 44)

    (treemacs-follow-mode t)
    (treemacs-filewatch-mode t)
    (treemacs-fringe-indicator-mode 'always)

    (pcase (cons (not (null (executable-find "git")))
                 (not (null treemacs-python-executable)))
      (`(t . t)
       (treemacs-git-mode 'deferred))
      (`(t . _)
       (treemacs-git-mode 'simple)))

    (treemacs-hide-gitignored-files-mode nil))
  :bind
  (:map global-map
        ("M-0"       . treemacs-select-window)
        ("C-x t 1"   . treemacs-delete-other-windows)
        ("C-x t t"   . treemacs)
        ("C-x t B"   . treemacs-bookmark)
        ("C-x t C-t" . treemacs-find-file)
        ("C-x t M-t" . treemacs-find-tag)))
(with-eval-after-load 'treemacs
  (define-key treemacs-mode-map [mouse-1] #'treemacs-single-click-expand-action))
(add-hook 'emacs-startup-hook 'treemacs)
;; ;; Are we on a mac?
;; ;; If so, we need to do some extra setup later
;; ;; i.e. re-binding the META-key to CMD instead of option
(setq is-mac (equal system-type 'darwin))

;; ;; Keep emacs Custom-settings in separate file
;; (setq custom-file (expand-file-name "custom.el" user-emacs-directory))
;; (load custom-file)

(setq backup-directory-alist
      `(("." . ,(expand-file-name
		 (concat user-emacs-directory "backups")))))

;; Make backups of files, even when they're in version control
(setq vc-make-backup-files t)

;; Set up saveplace - saves the cursor position in files you have previously opened
(save-place-mode 1)
(setq save-place-file (expand-file-name ".places" user-emacs-directory))

;; Start with sane(r) defaults
(require 'sane-defaults)

;; If this machine is a mac, do some specific setup
(when is-mac (require 'mac))

;; Enable upcase and downcase region (C-x C-u & C-x C-l)
(put 'downcase-region 'disabled nil)
(put 'upcase-region 'disabled nil)
;; (provide 'init)
;; ;;; init.el ends here
(use-package doom-themes
  :ensure t
  :config
  ;; Global settings (defaults)
  (setq doom-themes-enable-bold t    ; if nil, bold is universally disabled
        doom-themes-enable-italic t) ; if nil, italics is universally disabled

  (load-theme 'doom-one t)

  ;; Enable flashing mode-line on errors
  (doom-themes-visual-bell-config)
  ;; Enable custom neotree theme (all-the-icons must be installed!)
  (doom-themes-neotree-config)
  ;; or for treemacs users
  (setq doom-themes-treemacs-theme "doom-atom") ; use "doom-colors" for less minimal icon theme
  (doom-themes-treemacs-config)
  ;; Corrects (and improves) org-mode's native fontification.
  (doom-themes-org-config))

(custom-set-variables
 ;; custom-set-variables was added by Custom.
 ;; If you edit it by hand, you could mess it up, so be careful.
 ;; Your init file should contain only one such instance.
 ;; If there is more than one, they won't work right.
 '(custom-safe-themes
   '("7eea50883f10e5c6ad6f81e153c640b3a288cd8dc1d26e4696f7d40f754cc703" default))
 '(package-selected-packages
   '(doom-themes yasnippet which-key vertico use-package rainbow-delimiters marginalia highlight-numbers highlight-indent-guides fsharp-mode doom-modeline avy auctex)))
(custom-set-faces
 ;; custom-set-faces was added by Custom.
 ;; If you edit it by hand, you could mess it up, so be careful.
 ;; Your init file should contain only one such instance.
 ;; If there is more than one, they won't work right.
 )

