/// <binding Clean='clean' />
var gulp = require('gulp'),
    debug = require('gulp-debug'),
    less = require('gulp-less'),
    path = require('path'),
    concat = require('gulp-concat'),
    sourcemaps = require('gulp-sourcemaps'),
    rimraf = require('gulp-rimraf'),
    uglify = require('gulp-uglify');

var paths = {
    css: "./wwwroot/css",
    less: "./wwwroot/less",
    lib: "./wwwroot/lib"
};

var libs = [
    "node_modules/jquery/dist/jquery.js",
    "node_modules/jquery-validation/dist/jquery.validate.js",
    "node_modules/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js",
    "node_modules/tether/dist/js/tether.js",
    "node_modules/bootstrap/dist/js/bootstrap.js",
    "node_modules/bootstrap/dist/css/bootstrap.css",
    "node_modules/css-toggle-switch/dist/toggle-switch.css",
    "node_modules/font-awesome/css/font-awesome.min.css",
    "node_modules/tether/dist/js/tether.min.js"
];

var wwwrootLibs = [];
libs.forEach(function (element) {
    wwwrootLibs.push(paths.lib + element.slice(element.lastIndexOf('/')));
});

gulp.task("move-libs-to-wwwroot", function () {
    return gulp
        .src(libs)
        .pipe(gulp.dest(paths.lib));
});

// prepare LESS files
gulp.task("less-to-css", function () {
    return gulp
        .src(paths.less + "/*.less")
        .pipe(less())
        .pipe(gulp.dest(paths.css));
});

// cleanup
gulp.task("clean-css", function () {
    return gulp
        .src(paths.css + "/*.css", { read: false })
        .pipe(rimraf({ force: true }));
});

gulp.task("clean-libs", function () {
    return gulp
        .src(wwwrootLibs, { read: false })
        .pipe(rimraf({ force: true }));
});

gulp.task("clean", ["clean-css", "clean-libs"]);