
// функция изменения температуры
function DecreaseTemperature(initTemp, i){
    return initTemp * 0.1 / i;
}

// функция определения вероятности перехода в неоптимальное состояние
function GetTransitionProbability(dE, T){
    return Math.exp(-dE / T);
}

// функция решающая будет ли совершен переход в новое состояние
function is_Trnsaction(prob){
    if (prob > 1 || prob < 0){
        print("error!!!!!!!!!!!!!!!!!");
        exit();
    }
    let value = Math.random();
    if (value <= prob){
        return 1;
    }
    else{
        return 0;
    }
}

// А - координаты i-й точки    В - координаты i+1 точки;  обычное Эвклидово расстояние;
function Metric(A, B){
    console.log(`A= ${A},  B=${B}`);
    return ((A[0] - B[0]) ** 2 + (A[1] - B[1]) ** 2) ** 0.5;
}

// points - массив координат, считаем энергию для данного состояния(т.е. общее растояние)
function CalculateEnergy(points){
    let n = points.length;
    let E = 0;
    for (let i = 0; i < n-1; i++){
        E += Metric(points[i], points[i+1]);
    }
    // возврат к начальной точке, работает только в полносвязных графах
    E += Metric(points[n-1], points[0]);
    return E;
}

// создание нового сосояния, на основе points; выбирается случайный промежуток в массиве и реверсируется
function GenerateStateCandidate(points){
    let i = Math.floor(Math.random() * (points.length+1 - 0)) + 0;
    let j = Math.floor(Math.random() * (points.length+1 - 0)) + 0;

    if (i > j){
        let t = i;
        i = j;
        j = t;
    }

    let a = points.slice(0, i);
    let b = points.slice(i, j);

    b = b.reverse();

    let c = points.slice(j, points.length)
    let res = a.concat(b, c);
    return res;
}

// найти путь по номерам координат из points, возвращает список последовательно идущих номеров
function find_path(points){
    let path = [];
    for (let i=0; i<points.length; i++){
        path.push(points[i][2]);
    }

    return path;
}

// начальные значения
// 
//     startT - температура с которой начинаем
//     endT - температура, достигнув которой закончим цикл
//
function run(points, startT=10, endT= 0.0001){
    let from_x = 0;
    let finish_x = 80;
    let from_y = 0;
    let finish_y = 80;

    // отобразим точки и случайный маршут(здесь всегда берется от 0 до n-1)
    // state - последовательность номеров точек
    let state = find_path(points);
    console.log(`state: ${state}`);

    // подсчет энергии для данного состояния
    let currentEnergy = CalculateEnergy(points);
    
    // задаем начальное значение Т
    let T = startT;
    // переменные для "ловли" лучшего маршута
    let BestPath = state;
    let BestEnergy = currentEnergy;

    // введем ограничение по итерациям
    for (let i=0; i<1000; i++){
        // создаем состояние-кандидат
        let stateCandidate = GenerateStateCandidate(points);
        // находим энергию(длину пути) состояния кандидата
        let candidateEnergy = CalculateEnergy(stateCandidate);

        // если состояние кандидат имеет лучшую энергию(длину пути), то переходим в это состояние, если нет то переход будет осуществлен с вероятностью p
        if (candidateEnergy < currentEnergy){
            currentEnergy = candidateEnergy;
            points = stateCandidate.slice();
            state = find_path(points);
        }
        else{
            // подсчет вероятности р с которой будет совершен переход
            let p = GetTransitionProbability(candidateEnergy - currentEnergy, T)
            if (is_Trnsaction(p)){
                currentEnergy = candidateEnergy;
            points = stateCandidate.slice();
            state = find_path(points);
            }
        }
        // "ловля" лучшего решения
        if (currentEnergy < BestEnergy){
            BestEnergy = currentEnergy;
            BestPath = state;
        }
        // изменение температуры происходит согласно заданой функции
        T = DecreaseTemperature(startT, i);

        // если достигли температуры выхода, то выходим
        if (T <= endT){
            break;
        }
    }
    // выведем и отобразим лучший маршут

    return BestPath;
}


let arr = [[0, 0, 1], [5, 1, 2], [30, 50, 3], [4, 4, 4], [90, 80, 5], [1, 1, 6], [60, 60, 7]];
console.log(run(arr));