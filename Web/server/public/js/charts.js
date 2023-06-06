//  Game statistics charts

const ctx1 = document.getElementById("chart1").getContext("2d")
const ctx2 = document.getElementById("chart2").getContext("2d")

const fetchInformation = async (url, endpoint) => {
    try {
        const request = await fetch(`${url}${endpoint}`)
        const data = await request.json()
        return data
    } catch(error) {
        console.log({error})
    }
    
}

const randomColor = (alpha=1.0) =>
{
    const randomColor = () => Math.round(Math.random() * 255)
    return `rgba(${randomColor()}, ${randomColor()}, ${randomColor()}, ${alpha}`
}


// Most created weapons by players 

const createdWeaponsData = await fetchInformation('http://localhost:3000', '/api/createdWeaponsChart')

    const weaponNames = createdWeaponsData.map(({weapon_name}) => weapon_name)
    const playerCountChart1 = createdWeaponsData.map(({player_count}) => player_count)
    const colorsChart1 = createdWeaponsData.map(e => randomColor())
    const bordersChart1 = createdWeaponsData.map(e => 'rgba(0, 0, 0, 1.0)')

const createdWeaponsChart = new Chart(ctx1, 
    {
        type: 'bar',
        data: {
            labels: weaponNames,
            datasets: [
                {
                    label: 'Number of players that build a specific type of weapon',
                    backgroundColor: colorsChart1,
                    borderColor: bordersChart1,
                    data: playerCountChart1
                }
            ]
        }
    })


const playerDeathTypesData = await fetchInformation('http://localhost:3000', '/api/playerDeathTypes')

const deathTypes = playerDeathTypesData.map(({death_type}) => death_type)
const playerCountChart2 = playerDeathTypesData.map(({Player_Count}) => Player_Count)
const colorsChart2 = playerDeathTypesData.map(e => randomColor())
const bordersChart2 = playerDeathTypesData.map(e => 'rgba(0, 0, 0, 1.0)')

const playerDeathTypesChart = new Chart(ctx2, 
    {
        type: 'pie',
        data: {
            labels: deathTypes,
            datasets: [
                {
                    label: 'Number of Death Types',
                    backgroundColor: colorsChart2,
                    borderColor: bordersChart2,
                    data: playerCountChart2
                }
            ]
        }
    })
