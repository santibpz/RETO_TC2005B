// Game statistics charts

const ctx1 = document.getElementById("chart1").getContext("2d");
const ctx2 = document.getElementById("chart2").getContext("2d");
const ctx3 = document.getElementById("chart3").getContext("2d");
const ctx4 = document.getElementById("chart4").getContext("2d");

const fetchInformation = async (url, endpoint) => {
  try {
    const request = await fetch(`${url}${endpoint}`);
    const data = await request.json();
    return data;
  } catch (error) {
    console.log({ error });
  }
};

const randomColor = (alpha = 1.0) => {
  const randomColor = () => Math.round(Math.random() * 255);
  return `rgba(${randomColor()}, ${randomColor()}, ${randomColor()}, ${alpha})`;
};

// Most created weapons by players
const createdWeaponsData = await fetchInformation(
  "http://localhost:3000",
  "/api/createdWeaponsChart"
);

const weaponNames = createdWeaponsData.map(({ weapon_name }) => weapon_name);
const playerCountChart1 = createdWeaponsData.map(
  ({ player_count }) => player_count
);
const colorsChart1 = createdWeaponsData.map((e) => randomColor());
const bordersChart1 = createdWeaponsData.map((e) => "rgba(0, 0, 0, 1.0)");

const createdWeaponsChart = new Chart(ctx1, {
  type: "bar",
  data: {
    labels: weaponNames,
    datasets: [
      {
        label: "Number of players that build a specific type of weapon",
        backgroundColor: colorsChart1,
        borderColor: bordersChart1,
        data: playerCountChart1,
      },
    ],
  },
  options: {
    plugins: {
      legend: {
        labels: {
          color: "black",
          font: {
            size: 15 
            }
        },
      },
    },
  },
});

// Number of deaths registered under each type
const playerDeathTypesData = await fetchInformation(
  "http://localhost:3000",
  "/api/playerDeathTypes"
);

const deathTypes = playerDeathTypesData.map(({ death_type }) => death_type);
const playerCountChart2 = playerDeathTypesData.map(({ Player_Count }) => Player_Count);
const colorsChart2 = playerDeathTypesData.map((e) => randomColor());
const bordersChart2 = playerDeathTypesData.map((e) => "rgba(0, 0, 0, 1.0)");

const playerDeathTypesChart = new Chart(ctx2, {
  type: "pie",
  data: {
    labels: deathTypes,
    datasets: [
      {
        label: "Number of Death Types",
        backgroundColor: colorsChart2,
        borderColor: bordersChart2,
        data: playerCountChart2,
      },
    ],
  },
  options: {
    plugins: {
      legend: {
        labels: {
          color: "black",
          font: {
            size: 15
            }
        },
      },
    },
  },
});

// The number of upgrades registered for every weapon
const weaponUpgradesData = await fetchInformation(
  "http://localhost:3000",
  "/api/weaponUpgrades"
);

const upgradedWeapons = weaponUpgradesData.map(({ weapon_name }) => weapon_name);
const upgradeCount = weaponUpgradesData.map(({ upgrade_count }) => upgrade_count);
const colorsChart3 = weaponUpgradesData.map((e) => randomColor());
const bordersChart3 = weaponUpgradesData.map((e) => "rgba(0, 0, 0, 1.0)");

const weaponUpgradesChart = new Chart(ctx3, {
  type: "polarArea",
  data: {
    labels: upgradedWeapons,
    datasets: [
      {
        label: "Number of upgrades registered for every weapon",
        backgroundColor: colorsChart3,
        borderColor: bordersChart3,
        data: upgradeCount,
      },
    ],
  },
  options: {
    plugins: {
      legend: {
        labels: {
          color: "black", 
          font: {
            size: 15 
            }
        },
      },
    },
  },
});

// The number of deaths registered in every checkpoint
const checkpointDeaths = await fetchInformation(
  "http://localhost:3000",
  "/api/checkpointDeaths"
);

const checkpointId = checkpointDeaths.map(({ checkpoint }) => `Checkpoint ${checkpoint}`);
const loseCount = checkpointDeaths.map(({ total_lose_count }) => total_lose_count);
const colorsChart4 = checkpointDeaths.map((e) => randomColor());
const bordersChart4 = checkpointDeaths.map((e) => "rgba(0, 0, 0, 1.0)");

const checkpointDeathsChart = new Chart(ctx4, {
  type: "bar",
  data: {
    labels: checkpointId,
    datasets: [
      {
        label: "Number of deaths registered in every checkpoint",
        backgroundColor: colorsChart4,
        borderColor: bordersChart4,
        data: loseCount,
      },
    ],
  },
  options: {
    plugins: {
      legend: {
        labels: {
          color: "black",
          font: {
            size: 15
            }
        },
      },
    },
  },
});
