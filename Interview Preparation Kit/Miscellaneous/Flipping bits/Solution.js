'use strict';

const fs = require('fs');

process.stdin.resume();
process.stdin.setEncoding('utf-8');

let inputString = '';
let currentLine = 0;

process.stdin.on('data', inputStdin => {
    inputString += inputStdin;
});

process.stdin.on('end', function() {
    inputString = inputString.replace(/\s*$/, '')
        .split('\n')
        .map(str => str.replace(/\s*$/, ''));

    main();
});

function readLine() {
    return inputString[currentLine++];
}

// Complete the flippingBits function below.
function flippingBits(N) {
    let binary = N.toString(2),
        invertedBinary = '';
    
    for (var i = 0; i < binary.length; i++) {
        invertedBinary += binary[i] === "0" ? "1" : "0";
    }
    
    invertedBinary = invertedBinary.padStart(32, '1');

    return parseInt(invertedBinary, 2);
}

function main() {
    const ws = fs.createWriteStream(process.env.OUTPUT_PATH);

    const q = parseInt(readLine(), 10);

    for (let qItr = 0; qItr < q; qItr++) {
        const n = parseInt(readLine(), 10);

        const result = flippingBits(n);

        ws.write(result + '\n');
    }

    ws.end();
}