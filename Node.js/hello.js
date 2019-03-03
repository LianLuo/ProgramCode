/*var http = require("http");

http.createServer(function(request,response){
	
	response.writeHead(200,{'Content-Type':'text/plain'});
	
	response.end("hello,Universe! I'm running on Cloud Studio!\n");
	
}).listen(8088);

console.log("server running at http://local:8088/");
*/

function readFileAync(fileName)
{
	var fs = require("fs")
	
	var data = fs.readFileAync("C:/1.txt");
	
	console.info(data.toString());
	
	console.info("process finished.")
}

function readFileDync(fileName)
{
	var fs = require("fs");
	fs.readFile("C:/1.txt",function(err,data){
		if(err){
			return console.info(err);
		}
		return data.toString();
	});
	
	console.info('process finished.');
}
