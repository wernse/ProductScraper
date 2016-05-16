/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp'),
    templateCache = require('gulp-angular-templatecache'),
    ngAnnotate = require('gulp-ng-annotate'),
    concat = require('gulp-concat'),
    sass = require('gulp-sass');

/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

gulp.task('default', ['watch']);

gulp.task('templates', function () {
    return gulp.src('App/**/*.html')
      .pipe(templateCache({ standalone: true }))
      .pipe(ngAnnotate())
      .pipe(gulp.dest('Scripts'));
});

gulp.task('styles', function () {
    gulp.src(['Content/Site.scss', 'App/**/*.scss'])
    .pipe(sass({}))
    .pipe(concat('Site.css'))
    .pipe(gulp.dest('Content'))
})

gulp.task('watch', function () {
    console.log("watch")
    gulp.watch(['Content/Site.scss', 'App/**/*.scss'], ['styles']);
    gulp.watch('App/**/*.html', ['templates']);
});