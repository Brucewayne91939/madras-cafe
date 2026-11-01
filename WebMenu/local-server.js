const http = require('http');
const fs = require('fs');
const path = require('path');

const root = path.join(__dirname, 'dist');
const types = { '.css': 'text/css', '.js': 'text/javascript', '.html': 'text/html' };

http.createServer((request, response) => {
  const requested = request.url === '/' ? 'index.html' : decodeURIComponent(request.url.split('?')[0]);
  const file = path.join(root, requested);
  fs.readFile(file, (error, data) => {
    if (error) { response.writeHead(404); response.end('Not found'); return; }
    response.writeHead(200, { 'Content-Type': types[path.extname(file)] || 'application/octet-stream' });
    response.end(data);
  });
}).listen(5173, '0.0.0.0');
