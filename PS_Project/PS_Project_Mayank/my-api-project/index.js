const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors'); // Import CORS middleware
const swaggerJsdoc = require('swagger-jsdoc');
const swaggerUi = require('swagger-ui-express');
const moment = require('moment-timezone'); // Import moment-timezone

const app = express();
const port = 7102;

// Middleware
app.use(cors()); // Enable CORS for all routes
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));

// Example data (replace with your actual data source)
let userlists = [
  { Username: 'vijay', PasswordHash: 'passwordhash1', Email: 'vijay@gmail.com', LastLoginTime: '2024-06-01T12:00:00.000Z', CreatedAt: '2024-06-01T12:00:00.000Z', UpdatedAt: '2024-06-01T12:00:00.000Z' },
  { Username: 'rahul', PasswordHash: 'passwordhash2', Email: 'rahul@yahoo.com', LastLoginTime: '2024-06-02T12:00:00.000Z', CreatedAt: '2024-06-02T12:00:00.000Z', UpdatedAt: '2024-06-02T12:00:00.000Z' },
  { Username: 'anita', PasswordHash: 'passwordhash3', Email: 'anita@hotmail.com', LastLoginTime: '2024-06-03T12:00:00.000Z', CreatedAt: '2024-06-03T12:00:00.000Z', UpdatedAt: '2024-06-03T12:00:00.000Z' },
  { Username: 'arjun', PasswordHash: 'passwordhash4', Email: 'arjun@gmail.com', LastLoginTime: '2024-06-04T12:00:00.000Z', CreatedAt: '2024-06-04T12:00:00.000Z', UpdatedAt: '2024-06-04T12:00:00.000Z' },
  { Username: 'deepika', PasswordHash: 'passwordhash5', Email: 'deepika@yahoo.com', LastLoginTime: '2024-06-05T12:00:00.000Z', CreatedAt: '2024-06-05T12:00:00.000Z', UpdatedAt: '2024-06-05T12:00:00.000Z' },
  { Username: 'manoj', PasswordHash: 'passwordhash6', Email: 'manoj@hotmail.com', LastLoginTime: '2024-06-06T12:00:00.000Z', CreatedAt: '2024-06-06T12:00:00.000Z', UpdatedAt: '2024-06-06T12:00:00.000Z' }
];

// Swagger options
const swaggerOptions = {
  swaggerDefinition: {
    openapi: '3.0.0',
    info: {
      title: 'Simple API with Swagger',
      version: '1.0.0',
      description: 'A simple API with Swagger integration'
    },
  },
  apis: ['index.js'], // Specify the file path where your API routes are defined
};

const swaggerSpec = swaggerJsdoc(swaggerOptions);

// Serve Swagger UI
app.use('/api-docs', swaggerUi.serve, swaggerUi.setup(swaggerSpec));

/**
 * @swagger
 * /api/userlists:
 *   get:
 *     summary: Returns a list of userlists
 *     description: Returns a list of userlists from the database
 *     responses:
 *       '200':
 *         description: A JSON array of userlists
 *         content:
 *           application/json:
 *             schema:
 *               type: array
 *               items:
 *                 type: object
 *                 properties:
 *                   Username:
 *                     type: string
 *                   PasswordHash:
 *                     type: string
 *                   Email:
 *                     type: string
 *                   LastLoginTime:
 *                     type: string
 *                     format: date-time
 *                   CreatedAt:
 *                     type: string
 *                     format: date-time
 *                   UpdatedAt:
 *                     type: string
 *                     format: date-time
 *   post:
 *     summary: Add a new user to the userlists
 *     description: Add a new user object to the userlists array
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             type: object
 *             properties:
 *               Username:
 *                 type: string
 *               PasswordHash:
 *                 type: string
 *               Email:
 *                 type: string
 *     responses:
 *       '200':
 *         description: Successfully added the user
 *       '400':
 *         description: Invalid request body
 */
app.post('/api/userlists', (req, res) => {
  const { Username, PasswordHash, Email } = req.body;
  if (!Username || !PasswordHash || !Email) {
    return res.status(400).send('Invalid request body');
  }

  // Get current time in IST
  const currentTime = moment().tz('Asia/Kolkata').format(); // Convert to ISO string in IST

  const newUser = {
    Username,
    PasswordHash,
    Email,
    LastLoginTime: currentTime,
    CreatedAt: currentTime,
    UpdatedAt: currentTime
  };

  userlists.push(newUser);
  res.status(200).json(newUser);
});

// Endpoint to get all userlists
app.get('/api/userlists', (req, res) => {
  res.json(userlists);
});

// Root route handler
app.get('/', (req, res) => {
  res.send('Welcome to my API!'); // Example response
});

// Start the server
app.listen(port, () => {
  console.log(`Server is running at http://localhost:${port}`);

});