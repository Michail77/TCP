import axios from "axios";

export const API_KEY = "ee7c3b7c8b273b06e3df01668c3d0315"; // https://openweathermap.org/api
export const ROOT_URL = `http://api.openweathermap.org/data/2.5/weather`;

const FETCH_PLACE = "FETCH_PLACE";

const initialState = {places: [], busy: false, error: null};

export const fetchPlace = (name) => {
    return {type: FETCH_PLACE,payload:axios.get(ROOT_URL + "?q=" + name + "&appid=" + API_KEY + "&units=metric",{})};
};

export const reducer = (state, action) => {
    if (Object.entries(state).length === 0 && state.constructor === Object)
        state = initialState;
    console.log(state,action);
    switch (action.type) {
        case FETCH_PLACE + "_FULFILLED": {
            let places = [...state.places];
            places.push(action.payload.data);
            return {...state, busy:false,error:null, places:places};
        }
        case FETCH_PLACE + "_PENDING": {
            return {...state,  busy:true,error:null};
        }
        case FETCH_PLACE + "_REJECTED": {
            return {...state,  busy:false,error:"BUM"};
        }
        default: {
            return state;
        }
    }
};