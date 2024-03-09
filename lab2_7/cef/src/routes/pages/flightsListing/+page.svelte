<script lang="ts">
  import Icon from "@iconify/svelte";
  import { onMount } from "svelte";
  import "./styles.scss";

  let flightsFrom: string;
  let flightsTo: string;
  let flightsDepartureDate: Date;
  let flightsTickets: number = 1;
	let flightsClass: string = 'Economy';

  let countShowed = 0;
  let countMaxShowed = 0;

  let ticketsArray: any[] = [];

  $: countShowed = ticketsArray.length;

  const findFlights = async() => {
		if (flightsFrom && flightsTo && flightsDepartureDate && flightsClass && flightsTickets) {
			if (flightsFrom.length < 1 || flightsTo.length < 1 || flightsTickets < 1 || flightsClass.length < 1) {
				alert('Please fill in all fields');
				return;
			}

      const dateSplit = flightsDepartureDate.toString().split('-');

			await CefSharp.BindObjectAsync("boundAsync", "bound");
			boundAsync.getFlights(flightsFrom, flightsTo, [dateSplit[0], dateSplit[1], dateSplit[2]], flightsClass, flightsTickets);
		}
		else {
			alert('Please fill in all fields');
				return;
		}
	}

  onMount(() => {
    window.getTicketsFromListening = function (from: string, to: string, date: string, passengerClass: number) {
      flightsFrom = from;
      flightsTo = to;
      flightsDepartureDate = date;
      flightsPassengerClass = passengerClass;

      findFlights();
    }

    window.loadTicketsToListening = function(id: number, rating: number, name: string, price: number, type: string, departureTime: string, arrivedTime: string) {
      ticketsArray.push({
        id,
        rating,
        name,
        price,
        type,
        departureTime,
        arrivedTime
      })

      ticketsArray = Array.from(ticketsArray);
    }

    const tickets = [
      {
        id: 0,
        rating: 4.2,
        name: "Emirates",
        price: 104,
        type: "Economy",
        departureTime: "10:00 pm",
        arrivedTime: "11:00 pm",
      },
      {
        id: 0,
        rating: 4.2,
        name: "Emirates",
        price: 104,
        type: "Economy",
        departureTime: "10:00 pm",
        arrivedTime: "11:00 pm",
      },
      {
        id: 0,
        rating: 4.2,
        name: "Emirates",
        price: 104,
        type: "Economy",
        departureTime: "10:00 pm",
        arrivedTime: "11:00 pm",
      },
      {
        id: 0,
        rating: 4.2,
        name: "Emirates",
        price: 104,
        type: "Economy",
        departureTime: "10:00 pm",
        arrivedTime: "11:00 pm",
      },
      {
        id: 0,
        rating: 4.2,
        name: "SkyUp",
        price: 104,
        type: "Economy",
        departureTime: "10:00 pm",
        arrivedTime: "11:00 pm",
      },
    ]

    ticketsArray = Array.from(tickets);
    
  }) 
</script>

<section id="fligthListing">
  <header>
    <div id="chooseTicket">
      <div class="container">
        <div class="form">
          <div class="element">
            <span>From - To</span>
            <div class="inputs">
              <input
                type="text"
                placeholder="From..."
                bind:value={flightsFrom}
              />
              <span>-</span>
              <input type="text" placeholder="To..." bind:value={flightsTo} />
            </div>
          </div>
          <div class="element">
            <span>Trip</span>
            <select name="" id="">
              <option value="">Departure</option>
            </select>
          </div>
          <div class="element">
            <span>Depart day</span>
            <input
              type="date"
              name=""
              id=""
              bind:value={flightsDepartureDate}
            />
          </div>
          <div class="element">
            <span>Count tickets</span>
            <input type="number" placeholder="Count tickets" bind:value={flightsTickets}>
          </div>
          <div class="element">
            <span>Class</span>
            <select bind:value={flightsClass}>
              <option value="Economy">Economy</option>
              <option value="Business">Business</option>
              <option value="First">First class</option>
            </select>
          </div>
          <div class="buttons">
            <button><Icon icon="material-symbols:search" /></button>
          </div>
        </div>
      </div>
    </div>
  </header>

  <main>
    <div class="container">
      <div class="countShowed">
        Showed <span style="color: #FF8682">{countShowed}</span> tickets.
      </div>

      <div class="items">
        {#each ticketsArray as ticket}
          <div class="item">
            <div class="block">
              <div class="image">
                <img src="/images/flights/companys/{ticket.name}.png" alt="">
              </div>
    
              <div class="info">
                <div class="ratingPrice">
                  <div class="rating">
                    <span>{ticket.rating}</span>
                    <span>
                      {#if ticket.rating > 4}
                         Very Good
                      {:else if ticket.rating > 3}
                        Good
                      {:else}
                         Bad
                      {/if}
                    </span>
                  </div>
    
                  <div class="price">
                    <span>Price</span>
                    <span>${ticket.price}</span>
                  </div>
                </div>
    
                <div class="aboutTicket">
                  <div class="element">
                    <span>Departure - Arrived</span>
                    <span>{ticket.departureTime} - {ticket.arrivedTime}</span>
                  </div>

                  <div class="element">
                    <span>Transplants</span>
                    <span>non-stop</span>
                  </div>
                </div>
    
                <div class="btn">
                  <button>Buy ticket</button>
                </div>
              </div>
            </div>
          </div>
        {/each}
      </div>
    </div>
  </main>
</section>
