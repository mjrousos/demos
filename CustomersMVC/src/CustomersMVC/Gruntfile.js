/// <binding AfterBuild='jshint, copy' Clean='clean:wwwroot' />
/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {
    grunt.initConfig({
        clean: {
            wwwroot: ["wwwroot/*"]
        },

        jshint: {
            files: ['scripts/*.js']
        },

        copy: {
            bootstrap:
            {
                nonull: true,
                expand: true,
                cwd: 'bower_components/',
                src: ['bootstrap/dist/**'],
                dest: 'wwwroot/lib/'
            },
            jquery:
            {
                nonull: true,
                expand: true,
                cwd: 'bower_components/',
                src: ['jquery/dist/**'],
                dest: 'wwwroot/lib/'
            }
        },
    });

    grunt.loadNpmTasks("grunt-contrib-clean");
    grunt.loadNpmTasks("grunt-contrib-jshint");
    grunt.loadNpmTasks("grunt-contrib-copy");
};