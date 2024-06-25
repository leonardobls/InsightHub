var gulp = require('gulp');

gulp.task('copy-jquery', function () {
    return gulp.src('node_modules/jquery/dist/jquery.min.js')
        .pipe(gulp.dest('wwwroot/lib/jquery')); // ou 'Scripts/' para projetos MVC/Web Forms
});