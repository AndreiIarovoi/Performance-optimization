/**
 * System configuration for Angular samples
 * Adjust as necessary for your application needs.
 */
(function (global) {
    System.config({
        paths: {
            // paths serve as alias
            'npm:': '/node_modules/'
        },
        // map tells the System loader where to look for things
        map: {
            // our app is within the app folder
            app: '/Scripts',
            // angular bundles
            '@angular/core': 'npm:@angular/core/bundles/core.umd.js',
            '@angular/common': 'npm:@angular/common/bundles/common.umd.js',
            '@angular/compiler': 'npm:@angular/compiler/bundles/compiler.umd.js',
            '@angular/platform-browser': 'npm:@angular/platform-browser/bundles/platform-browser.umd.js',
            '@angular/platform-browser-dynamic': 'npm:@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.js',
            '@angular/http': 'npm:@angular/http/bundles/http.umd.js',
            '@angular/router': 'npm:@angular/router/bundles/router.umd.js',
            '@angular/forms': 'npm:@angular/forms/bundles/forms.umd.js',
            // other libraries
            'lodash': 'npm:lodash',
            'rxjs': 'npm:rxjs',
            'ngx-uploader': 'npm:ngx-uploader/bundles/ngx-uploader.umd.js',
            'ng2-simple-timer': 'npm:ng2-simple-timer',
            'angular2-uuid': 'npm:angular2-uuid',
            'ngx-pagination': 'npm:ngx-pagination/dist/ngx-pagination.umd.js',
            'ng2-nvd3': 'npm:ng2-nvd3',
            'nvd3': 'npm:nvd3/build/nv.d3.min.js',
            'd3': 'npm:d3/d3.js',
            'tslib': 'npm:tslib/tslib.js'
        },
        // packages tells the System loader how to load when no filename and/or no extension
        packages: {
            app: {
                main: './main.js',
                defaultExtension: 'js'
            },
            lodash: {
                main: 'index.js',
                defaultExtension: 'js'
            },
            rxjs: {
                defaultExtension: 'js'
            },
            "ng2-nvd3": {
                main: 'build/index.js',
                defaultExtension: 'js'
            },
            "angular2-uuid": {
                main: 'index.js',
                defaultExtension: 'js'
            },
            "ng2-simple-timer": {
                main: 'lib/simple-timer.js',
                defaultExtension: 'js'
            }
        }
    });
})(this);