(function ($) {
    'use strict';
    $(function () {
        var body = $('body');
        var contentWrapper = $('.content-wrapper');
        var scroller = $('.container-scroller');
        var footer = $('.footer');
        var sidebar = $('.sidebar');

        function addActiveClass(element) {
            var href = element.attr('href');
            if (href && !href.startsWith("javascript:")) {
                if (current === "") {
                    if (href.indexOf("index.html") !== -1) {
                        element.parents('.nav-item').last().addClass('active');
                        if (element.parents('.sub-menu').length) {
                            element.closest('.collapse').addClass('show');
                            element.addClass('active');
                        }
                    }
                } else {
                    if (href.indexOf(current) !== -1) {
                        element.parents('.nav-item').last().addClass('active');
                        if (element.parents('.sub-menu').length) {
                            element.closest('.collapse').addClass('show');
                            element.addClass('active');
                        }
                        if (element.parents('.submenu-item').length) {
                            element.addClass('active');
                        }
                    }
                }
            }
        }


        var current = location.pathname.split("/").slice(-1)[0].replace(/^\/|\/$/g, '');
        $('.nav li a', sidebar).each(function () {
            var $this = $(this);
            addActiveClass($this);
        })

        $('.horizontal-menu .nav li a').each(function () {
            var $this = $(this);
            addActiveClass($this);
        })

        sidebar.on('show.bs.collapse', '.collapse', function () {
            sidebar.find('.collapse.show').collapse('hide');
        });

        applyStyles();

        function applyStyles() {
            if (!body.hasClass("rtl")) {
                if ($('.settings-panel .tab-content .tab-pane.scroll-wrapper').length) {
                    const settingsPanelScroll = new PerfectScrollbar('.settings-panel .tab-content .tab-pane.scroll-wrapper');
                }
                if ($('.chats').length) {
                    const chatsScroll = new PerfectScrollbar('.chats');
                }
                if (body.hasClass("sidebar-fixed")) {
                    var fixedSidebarScroll = new PerfectScrollbar('#sidebar .nav');
                }
            }
        }

        $('[data-toggle="minimize"]').on("click", function () {
            if ((body.hasClass('sidebar-toggle-display')) || (body.hasClass('sidebar-absolute'))) {
                body.toggleClass('sidebar-hidden');
            } else {
                body.toggleClass('sidebar-icon-only');
            }
        });

        $(".form-check label,.form-radio label").append('<i class="input-helper"></i>');

        $("#fullscreen-button").on("click", function toggleFullScreen() {
            if ((document.fullScreenElement !== undefined && document.fullScreenElement === null) || (document.msFullscreenElement !== undefined && document.msFullscreenElement === null) || (document.mozFullScreen !== undefined && !document.mozFullScreen) || (document.webkitIsFullScreen !== undefined && !document.webkitIsFullScreen)) {
                if (document.documentElement.requestFullScreen) {
                    document.documentElement.requestFullScreen();
                } else if (document.documentElement.mozRequestFullScreen) {
                    document.documentElement.mozRequestFullScreen();
                } else if (document.documentElement.webkitRequestFullScreen) {
                    document.documentElement.webkitRequestFullScreen(Element.ALLOW_KEYBOARD_INPUT);
                } else if (document.documentElement.msRequestFullscreen) {
                    document.documentElement.msRequestFullscreen();
                }
            } else {
                if (document.cancelFullScreen) {
                    document.cancelFullScreen();
                } else if (document.mozCancelFullScreen) {
                    document.mozCancelFullScreen();
                } else if (document.webkitCancelFullScreen) {
                    document.webkitCancelFullScreen();
                } else if (document.msExitFullscreen) {
                    document.msExitFullscreen();
                }
            }
        })
    });
})(jQuery);


function nv(newPage, reloadTime) {
    window.location.href = newPage;
    setTimeout(function () {
        location.reload();
    }, reloadTime || 500); // Default reload time is 500 milliseconds
}


window.addScrollListener = (element) => {
    if (element) {
        let lastScrollTop = element.scrollTop;

        element.addEventListener('scroll', () => {
            let currentScroll = element.scrollTop;
            let direction = currentScroll > lastScrollTop ? 'down' : 'up';
            lastScrollTop = currentScroll;

            if (element.scrollHeight > element.clientHeight && direction === 'down') {
                element.style.scrollbarWidth = "thin";
                element.style.scrollbarColor = "rgba(0, 0, 0, 0.3) rgba(0, 0, 0, 0)";
                element.style.webkitScrollbarWidth = "thin";
                element.style.webkitScrollbarColor = "rgba(0, 0, 0, 0.3) rgba(0, 0, 0, 0)";
            } else {
                element.style.scrollbarWidth = "thin";
                element.style.scrollbarColor = "transparent transparent";
                element.style.webkitScrollbarWidth = "thin";
                element.style.webkitScrollbarColor = "transparent transparent";
            }
        });
    }
};
(function ($) {
    'use strict';
    $(function () {
        $('[data-toggle="offcanvas"]').on("click", function () {
            $('.sidebar-offcanvas').toggleClass('active')
        });
    });
})(jQuery);

(function ($) {
    'use strict';
    $(document).on('mouseenter mouseleave', '.sidebar .nav-item', function (ev) {
        var body = $('body');
        var sidebarIconOnly = body.hasClass("sidebar-icon-only");
        var sidebarFixed = body.hasClass("sidebar-fixed");
        if (!('ontouchstart' in document.documentElement)) {
            if (sidebarIconOnly) {
                if (sidebarFixed) {
                    if (ev.type === 'mouseenter') {
                        body.removeClass('sidebar-icon-only');
                    }
                } else {
                    var $menuItem = $(this);
                    if (ev.type === 'mouseenter') {
                        $menuItem.addClass('hover-open')
                    } else {
                        $menuItem.removeClass('hover-open')
                    }
                }
            }
        }
    });
})(jQuery);

