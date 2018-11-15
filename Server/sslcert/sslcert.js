var fs = require('fs');

var http = require('http');
const pem = require('pem');

module.exports = class Cert {
    constructor() { }

    requestCert() {
        console.log("Request a new ssl certificate..");
        this.pfxCert = fs.createWriteStream('sslcert/server.pfx');
        this.req = http.get('http://localhost:8081/cert/getSubCert', function (response) {
            response.pipe(pfxCert);
            pfxCert.on('finish', function () {
                console.log("Request successful...");
                return this.option = {
                    pfx: fs.readFileSync('sslcert/server.pfx'),
                    passphrase: 'password'
                };
            });
        });
    }

    getCert() {
        //var newCert = this.requestCert();
        //if (newCert != null) {
        //    return newCert;
        //} else {
            return this.option = {
                pfx: fs.readFileSync('sslcert/server.pfx'),
                passphrase: 'password'
            };
        //}
    }
}

//var fs = require('fs');
//var privateKey = fs.readFileSync('sslcert/server.key', 'utf8');
//var certificate = fs.readFileSync('sslcert/server.crt', 'utf8');
//var credentials = { key: privateKey, cert: certificate };
//var credentials = { key: privateKey, cert: certificate };
//module.exports = credentials;