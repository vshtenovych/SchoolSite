var slideout = new Slideout({
        'panel': document.getElementById('main'),
        'menu': document.getElementById('mobile-menu'),
        'padding': 350,
        'tolerance': 70
      });
      document.querySelector('.js-slideout-toggle').addEventListener('click', function() {
        slideout.toggle();
      });
