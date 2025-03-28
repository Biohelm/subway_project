import axios from 'axios';

const API_URL = 'https://your-api-endpoint.com/products'; 

export const getProducts = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data; 
  } catch (error) {
    console.error('Error fetching products:', error);
    throw error;
  }
};
