import { writable } from "svelte/store"; 

export const activePage = writable(0);
export const name = writable('');
export const email = writable('');

export const flightsFrom = writable('');
export const flightsTo = writable('');
export const flightsDepartureDate = writable(new Date());
export const flightsTickets = writable(1);
export const flightsClass = writable('Economy');

export const popupData = writable(
{
  title: '', 
  returnType: '',
});