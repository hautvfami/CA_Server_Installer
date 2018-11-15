'use strict';
var express = require('express');
var router = express.Router();
var credentials = require('../../sslcert/sslcert');

/* GET home page. */
router.get('/', function (req, res) {
    res.writeHead(200, { 'Content-Type': 'application/force-download', 'Content-Disposition': 'attachment; filename="cert.crt"' });
    res.end(credentials.cert);
});

module.exports = router;