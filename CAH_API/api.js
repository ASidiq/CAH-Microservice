require('dotenv').config();
const express = require('express')
const fs = require('fs')
const app = express();
const port = process.env.PORT || 8000;
const json_file = "./cah_geek_food.json";

app.listen(port, () => {
    console.log(`listening on port ${port}!`)
});

app.get('/', (req, res) => {
    res.send('Hello World!');
});

app.get('/question/foodpack', (req, res) => {
    const content = JSON.parse(fs.readFileSync(json_file, 'utf-8'));
    const max = content[0].black.length
    res.json(content[0].black[Math.floor(Math.random() * max)]);
});

app.get('/question/geekpack', (req, res) => {
    const content = JSON.parse(fs.readFileSync(json_file, 'utf-8'));
    const max = content[1].black.length
    let answerCount, question;
    do {
        question = content[1].black[Math.floor(Math.random() * max)]
        answerCount = question.pick
    } while (answerCount !== 1);
    res.json(question);
});

app.get('/answer/foodpack', (req, res) => {
    const content = JSON.parse(fs.readFileSync(json_file, 'utf-8'));
    const max = content[0].white.length;
    res.json(content[0].white[Math.floor(Math.random() * max)]);
});

app.get('/answer/geekpack', (req, res) => {
    const content = JSON.parse(fs.readFileSync(json_file, 'utf-8'));
    const max = content[1].white.length;
    res.json(content[1].white[Math.floor(Math.random() * max)]);
});

