'use strict';
var debug = require('debug');
var express = require('express');
var path = require('path');
var favicon = require('serve-favicon');
var logger = require('morgan');
var cookieParser = require('cookie-parser');
var bodyParser = require('body-parser');
var dotenv = require('dotenv');

var http = require('http');
var https = require('https');
var Cert = require('./sslcert/sslcert');

var routes = require('./routes/index');
var users = require('./routes/users');
var cert = require('./routes/api/cert');

var app = express();
dotenv.config();

// view engine setup
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'pug');

// uncomment after placing your favicon in /public
app.use(favicon(__dirname + '/public/favicon.ico'));
app.use(logger('dev'));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));

app.use('/', routes);
app.use('/users', users);

app.use('/api/cert', cert);

// catch 404 and forward to error handler
app.use(function (req, res, next) {
    var err = new Error('Not Found');
    err.status = 404;
    next(err);
});

// error handlers

// development error handler
// will print stacktrace
if (app.get('env') === 'development') {
    app.use(function (err, req, res, next) {
        res.status(err.status || 500);
        res.render('error', {
            message: err.message,
            error: err
        });
    });
}

// production error handler
// no stacktraces leaked to user
app.use(function (err, req, res, next) {
    res.status(err.status || 500);
    res.render('error', {
        message: err.message,
        error: {}
    });
});

//app.set('port', process.env.PORT || 3000);
//var server = app.listen(app.get('port'), function () {
//    debug('Express server listening on port ' + server.address().port);
//});


app.set('port', process.env.PORT || 8080);
app.set('ssl_port', process.env.SSL_PORT || 8443);

var httpServer = http.createServer(app);
var Cert = new Cert();
var option = Cert.getCert();
var httpsServer = https.createServer(option, app);

httpServer.listen(8080, function () {
    console.log('Express http server listening on port ' + 8080);
});
httpsServer.listen(8443, function () {
    console.log('Express https server listening on port ' + 8443);
});