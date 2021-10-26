const colors = require('tailwindcss/colors')

module.exports = {
    mode: 'jit',
    purge: [
        './wwwroot/index.html',
        './**/*.razor',
    ],
    darkMode: 'media',
    theme: {
        extend: {
            colors: {
                cyan: colors.cyan,
                prim: '#c977f7',
                sec: '#af38f2',
            }
        },
    },
    variants: {
        extend: {},
    },
    plugins: [
        require('tailwindcss-textshadow')
    ]
}