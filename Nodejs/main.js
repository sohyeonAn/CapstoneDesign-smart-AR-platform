// JavaScript source code
var http = require('http');
var url = require('url');
var fs = require('fs');

var express = require('express');
var app = express();

// 1. mime ��� �߰�. �����Ϸ��� ������ Ÿ���� �˾Ƴ��� ���ؼ� �ʿ�
var mime = require('mime');

app.use(express.static('public'));

app.get('/:path', function (request, response) {
	var filename = request.params.path;
	console.log(filename);
	
	fs.readFile('resources/' + filename, function (error, data) {
     		if(error){
       			
      		}else{
       			 response.send(data);
     		 }
        
	});
});

var server=app.listen('3000',function(){
    console.log('server started on 3000');
});