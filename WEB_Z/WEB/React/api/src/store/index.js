import axios from "axios";

const URL = "http://api.icndb.com/";
const FETCH_JOKE = "FETCH_JOKE";
const FETCH_CATEGORIES = "FETCH_CATEGORIES";

export const FetchJoke = (category) => {
    return {type: FETCH_JOKE , payload: axios.get(URL + "jokes/random",{
        params:{
            limitTo:"["+category+"]"}
        })}};
export const FetchCategories = () =>{
    return {type: FETCH_CATEGORIES , payload: axios.get(URL + "categories",{})}};

export const reducer = (state, action) => {
    switch (action.type) {
        case FETCH_JOKE + "_FULFILLED": {
            return {...state, busy:false,error:null, joke:action.payload.data.value.joke,category:action.payload.data.value.categories[0]};
        }
        case FETCH_JOKE + "_PENDING": {
            return {...state,  busy:true,error:null};
        }
        case FETCH_JOKE + "_REJECTED": {
            return {...state,  busy:false,error:"BUM"};
        }

        case FETCH_CATEGORIES + "_FULFILLED": {
            return {...state, busy:false,error:null, categories:action.payload.data.value};
        }
        case FETCH_CATEGORIES + "_PENDING": {
            return {...state,  busy:true,error:null};
        }
        case FETCH_CATEGORIES + "_REJECTED": {
            return {...state,  busy:false,error:"BUM"};
        }
        default: {
            return state;
        }
    }
}