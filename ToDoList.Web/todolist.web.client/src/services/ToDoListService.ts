import { GetData } from "../Helpers/SessionHelper";

const baseUrl = 'https://localhost:7223/api/ToDoList/GetItems/';

const headers = new Headers({
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Allow-Methods': 'POST,PATCH,OPTIONS',
    'referrerPolicy': 'origin',
    'Authorization': `Bearer ${GetData("accessToken")}`
});


async function GetDoToItems() {
    const response = await fetch(baseUrl, {
        method: 'GET',
        headers: headers
    });
    return await response.json();
}


export { GetDoToItems };