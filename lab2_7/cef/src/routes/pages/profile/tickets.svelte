<script lang="ts">
  import Icon from '@iconify/svelte';
  import { onMount } from 'svelte';
  import { email } from '../../states';

  let flightTicketArray: any[] = [];

  let activeType = 0;

  let nav: HTMLElement | null = null;

  const changeActiveType = (page: number) => {
    if (nav) {
      const list = nav.querySelectorAll('li');
      
      if (list[activeType].classList.contains('active')) {
        nav.querySelectorAll('li')[activeType].classList.remove('active');
      }
      nav.querySelectorAll('li')[page].classList.add('active');
      console.log('mark acitve')
    }
    activeType = page;
  }

  onMount(async() => {
    nav = document.getElementById('navigationTickets');

    flightTicketArray.splice(0, flightTicketArray.length);

    await CefSharp.BindObjectAsync("boundAsync", "bound");
    boundAsync.getPurchasedTickets($email);

    window.loadFlightsTickets = function (companyName: string, from: string, fromTime: string, to: string, toTime: string, date: string) {
      flightTicketArray.push({
        companyName,
        from,
        fromTime,
        to,
        toTime,
        date
      })
      flightTicketArray = Array.from(flightTicketArray);
    }
  })
</script>

<section>
  <nav id="navigationTickets">
    <li class="active" on:click={() => changeActiveType(0)}>
      <Icon icon="mdi:flight" /> Flights
    </li>
    <li on:click={() => changeActiveType(1)}>
      <Icon icon="material-symbols:hotel" /> Stays
    </li>
  </nav>

  <main>
    {#if activeType == 0}
      {#each flightTicketArray as item}
      <div class="element">
        <div class="container">
          <div class="img">
            <img src="/images/flights/companys/{item.companyName}.png" alt="">
          </div>

          <div class="fromTo">
            <div class="block">
              <span>{item.from}</span>
              <span>{item.fromTime}</span>
            </div>

            <div class="minus">
              <Icon icon="ph:minus" />
            </div>

            <div class="block">
              <span>{item.to}</span>
              <span>{item.toTime}</span>
            </div>
          </div>

          <div class="info">
            <div class="block">
              <div class="item">
                <div class="icon">
                  <Icon icon="clarity:date-line" />
                </div>
                <div class="text">
                  <span>Date</span>
                  <span>{item.date}</span>
                </div>
              </div>
            </div>
            <div class="block">
              <div class="item">
                <div class="icon">
                  <Icon icon="clarity:date-line" />
                </div>
                <div class="text">
                  <span>Gate</span>
                  <span>A12</span>
                </div>
              </div>
              <div class="item">
                <div class="icon">
                  <Icon icon="clarity:date-line" />
                </div>
                <div class="text">
                  <span>Seat no.</span>
                  <span>{Math.floor(Math.random() * 100)}</span>
                </div>
              </div>
            </div>
          </div>
        </div>
       </div>
      {/each}
    {:else}
       <!-- else content here -->
    {/if}
  </main>
</section>

<style lang="scss">
  section {
    display: flex;
    flex-direction: column;
    gap: 20px;

    nav {
      display: flex;
      flex-direction: row;
      justify-content: start;
      align-items: center;

      background: #FFF;
      border-radius: 12px;

      padding: 20px;

      .active {
        color: #8DD3BB;
      }
      li {
        display: flex;
        flex-direction: row;
        align-items: center;
        gap: 10px;

        width: 50%;

        list-style: none;

        font-size: 20px;
        font-weight: 700;
        color: #000;

        transition: color ease-in-out 0.3s;

      }
    }

    main {
      display: flex;
      flex-direction: column;
      gap: 5px;

      .element {
        background: #FFF;
        border-radius: 12px;
        width: 100%;
        height: auto;

        .container {
          padding: 20px;
          display: flex;
          flex-direction: row;
          justify-content: start;
          gap: 5%;

          .img {
            display: flex;
            flex-direction: row;
            align-items: center;

            padding: 10px;

            border: 1px solid #8DD3BB;
            border-radius: 6px;

            img {
              width: 90px;
              height: 90px;
            }
          }

          .fromTo {
            display: flex;
            flex-direction: row;
            align-items: center;
            justify-content: center;
            gap: 10px;

            .block {
              display: flex;
              flex-direction: column;
              gap: 5px;

              span:nth-child(2) {
                font-size: 20px;
                font-weight: 700;
              }
            }

            .minus {
              font-size: 20px;
              color: #000;
            }
          }

          .info {
            display: flex;
            flex-direction: row;
            gap: 30px;

            .block {
              display: flex;
              flex-direction: column;
              justify-content: space-between;

              .item {
                display: flex;
                flex-direction: row;
                align-items: center;
                gap: 5px;

                .icon {
                  display: flex;
                  flex-direction: row;
                  justify-content: center;
                  align-items: center;

                  font-size: 16px;

                  padding: 5px;
                  background: #8DD3BB;
                  border-radius: 5px;
                }

                .text {
                  display: flex;
                  flex-direction: column;
                  gap: 2px;

                  span:nth-child(1) {
                    font-size: 14px;
                    font-weight: 600;
                  }

                  span:nth-child(2) {
                    font-size: 16px;
                    font-weight: 700;
                  }
                }
              }
            }
          }
        }
      }
    }
  }
</style>