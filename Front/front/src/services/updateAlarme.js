import axios from 'axios';

export default async function updateAlarm(id,alarme)
{
    return axios
        .put(`https://localhost:44320/api/Alarmes/${id}`,alarme)
        .then(response=>{
            return response.data
        })

}