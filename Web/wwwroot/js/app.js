addEventListener('DOMContentLoaded', () => {

    // Check direction
    // Dependency for Masonry layout
    dir = () => {
        if (document.querySelector('html[dir=rtl]') || document.querySelector('.c-rtl')) {
            return false
        } else if (document.querySelector('html[dir=ltr]') || document.querySelector('.c-ltr')) {
            return true
        }
    }

})