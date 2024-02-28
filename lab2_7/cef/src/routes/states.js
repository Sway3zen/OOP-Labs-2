import { writable } from "svelte/store"; 

export const activePage = writable(0);
export const name = writable('');
export const email = writable('');