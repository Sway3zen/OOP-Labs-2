<script lang="ts">
  import Icon from '@iconify/svelte';

  let selectedType = 0;

  const changeActiveType = (type: number) => {
    const nav = document.getElementById('navigation');
    nav?.querySelectorAll('.element')[selectedType].classList.remove('active');

    selectedType = type;

    nav?.querySelectorAll('.element')[type].classList.add('active');
  }

  let flightAirlines: string;
  let flightFrom: string;
  let flightTo: string;
  let flightDepartureDate: string;
  let flightDepartureTime: string;
  let flightArrivalDate: string;
  let flightArrivalTime: string;
  let flightEconomyPrice: number;
  let flightEconomyTickets: number;
  let flightBusinessPrice: number;
  let flightBusinessTickets: number;
  let flightFirstClassPrice: number;
  let flightFirstClassTickets: number;

  const tryAddFlight = async() => {
    if (flightAirlines && flightFrom && flightTo && flightDepartureDate && flightDepartureTime && flightArrivalDate && flightArrivalTime && flightEconomyPrice && flightEconomyTickets && flightBusinessPrice && flightBusinessTickets && flightFirstClassPrice && flightFirstClassTickets) {
      if (flightEconomyTickets < 1 || flightBusinessTickets < 1 || flightFirstClassTickets < 1 || flightEconomyPrice < 1 || flightBusinessPrice < 1 || flightFirstClassPrice < 1) {
        alert('Please fill in all fields');
        return;
      }      
    }
    else {
      alert('Please fill in all fields');
      return;
    }


    await CefSharp.BindObjectAsync("boundAsync", "bound");
    boundAsync.addFlight(
      flightAirlines,
      [flightFrom,
      flightTo],
      [flightDepartureDate,
      flightDepartureTime],
      [flightArrivalDate,
      flightArrivalTime],
      [flightEconomyPrice,
      flightEconomyTickets,
      flightBusinessPrice,
      flightBusinessTickets,
      flightFirstClassPrice,
      flightFirstClassTickets]
    )

    flightAirlines = '';
    flightFrom = '';
    flightTo = '';
    flightDepartureDate = '';
    flightDepartureTime = '';
    flightArrivalDate = '';
    flightArrivalTime = '';
    flightEconomyPrice = 0;
    flightEconomyTickets = 0;
    flightBusinessPrice = 0;
    flightBusinessTickets = 0;
    flightFirstClassPrice = 0;
    flightFirstClassTickets = 0;
  }
</script>

<section>
  <div class="container">
    <nav id="navigation">
      <div class="element active" on:click={() => changeActiveType(0)}>
        <Icon icon="clarity:plane-solid" />
        <span>Flights</span>
      </div>
      <div class="element" on:click={() => changeActiveType(1)}>
        <Icon icon="fluent-emoji-high-contrast:hotel" />
        <span>Hotels</span>
      </div>
    </nav>

    {#if selectedType == 0}
       <div class="form">
          <div class="element">
            <div class="block">
              <span>Airlines</span>
              <input type="text" name="" id="" bind:value={flightAirlines}>
            </div>
          </div>
          <div class="element">
            <div class="block">
              <span>Departure From</span>
              <input type="text" name="" id="" bind:value={flightFrom}>
            </div>
            <div class="block">
              <span>Arrival To</span>
              <input type="text" name="" id="" bind:value={flightTo}>
            </div>
          </div>
          <div class="element">
            <div class="block">
              <span>Departure Date</span>
              <input type="date" name="" id="" bind:value={flightDepartureDate}>
            </div>
            <div class="block">
              <span>Departure Time</span>
              <input type="time" name="" id="" bind:value={flightDepartureTime}>
            </div>
          </div>
          <div class="element">
            <div class="block">
              <span>Arrival Date</span>
              <input type="date" name="" id="" bind:value={flightArrivalDate}>
            </div>
            <div class="block">
              <span>Arrival Time</span>
              <input type="time" name="" id="" bind:value={flightArrivalTime}>
            </div>
          </div>
          <div class="element">
            <div class="block">
              <span>Economy class tickets</span>
              <input type="text" name="" id="" bind:value={flightEconomyTickets}>
            </div>
            <div class="block">
              <span>Economy class ticket price</span>
              <input type="text" name="" id="" bind:value={flightEconomyPrice}>
            </div>
          </div>
          <div class="element">
            <div class="block">
              <span>Business class tickets</span>
              <input type="text" name="" id="" bind:value={flightBusinessTickets}>
            </div>
            <div class="block">
              <span>Business class ticket price</span>
              <input type="text" name="" id="" bind:value={flightBusinessPrice}>
            </div>
          </div>
          <div class="element">
            <div class="block">
              <span>First class tickets</span>
              <input type="text" name="" id="" bind:value={flightFirstClassTickets}>
            </div>
            <div class="block">
              <span>First class ticket price</span>
              <input type="text" name="" id="" bind:value={flightFirstClassPrice}>
            </div>
          </div>

          <div class="btn">
            <button on:click={() => tryAddFlight()}>
              <Icon icon="ic:baseline-create" /> Create flight
            </button>
          </div>
       </div>
    {:else}
       <!-- else content here -->
    {/if}
  </div>
</section>

<style lang="scss">
  section {
    padding: 0 7.5%;

    padding-top: 30px;
    padding-bottom: 130px;

    .container {
      background: #FFF;
      border-radius: 6px;
      padding: 30px;

      display: flex;
      flex-direction: column;
      gap: 10px;

      nav {
        display: flex;
        flex-direction: row;
        justify-content: left;
        align-items: center;

        gap: 30px;

        .element {
          display: flex;
          flex-direction: row;
          align-items: center;

          gap: 5px;

          transition: color ease-in-out 0.4s;
        }

        .element.active {
          color: #ff3e00;
        }
      }

      .form {
        display: flex;
        flex-direction: column;
        gap: 10px;

        .element {
          display: flex;
          flex-direction: row;
          justify-content: space-between;

          .block {
            display: flex;
            flex-direction: column;
            width: 48%;

            span {
              font-size: 14px;
              font-weight: 500;
            }

            input {
              box-sizing: border-box;
              background: transparent;

              outline: none;

              border: 1px solid rgba(23,23,23,0.5);
              border-radius: 6px;

              padding: 10px 15px;
            }
          }
        }

        .btn {
          padding-top: 10px;

          display: flex;
          flex-direction: row;
          justify-content: right;

          button {
          width: fit-content;
          
          padding: 10px 15px;

          display: flex;
          flex-direction: row;
          align-items: center;
          gap: 5px;

          background: hsl(209, 36%, 86%);

          border: none;
          outline: none;
          border-radius: 6px;

          color: #000;
          font-size: 16px;
          font-weight: 500;
          }
        }
      }
    }
  }
</style>