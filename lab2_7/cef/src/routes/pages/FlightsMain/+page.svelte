<script lang="ts">
  import Icon from '@iconify/svelte';
  import { onMount } from 'svelte';
  import './styles.scss';

  
  import ComponentFindTicket from '../../components/findTicket.svelte';
</script>

<section id="flightsMain">
  <header>
    <img loading="eager" src="/images/flights/main/FlightsMain.png" alt="">

    <div class="text">
      <span>Make your travel whishlist, we’ll do the rest</span>
      <span>Special offers to suit your plan</span>
    </div>

    <div class="chooseTicket">
      <ComponentFindTicket />
    </div>
  </header>

  <main>
    <div class="goTogether">
      <div class="container">
        <div class="block">
          <div class="text">
            <span>Let’s go places together</span>
            <span>Discover the latest offers and news start planning your next trip with us</span>
          </div>
          <div class="btnSeeAll">
            <button>See all</button>
          </div>
        </div>
      </div>

      <img src="/images/flights/main/geoExample.png" alt="" class="goTogetherImage">
    </div>

    <div class="goTogether">
      <div class="container">
        <div class="block">
          <div class="text">
            <span>Fall into travel</span>
            <span>Going somewhere to celebrate this season? Whether you’re going home or somewhere to roam, we’ve got the travel tools to get you to your destination.</span>
          </div>
          <div class="btnSeeAll">
            <button>See all</button>
          </div>
        </div>
        <div class="exampleTickets">
          <div class="card">
            <img src="/images/flights/main/Melbourne.png" alt="">

            <div class="info">
              <div class="container">
                <div class="text">
                  <div class="title">
                    <span>Melbourne</span>
                    <span>An amazing journey</span>
                  </div>
                  <div class="price">
                    <span>$ 700</span>
                  </div>
                </div>
  
                <div class="btn">
                  <button>Book Flight</button>
                </div>
              </div>
            </div>
          </div>

          <div class="card">
            <img src="/images/flights/main/Paris.png" alt="">

            <div class="info">
              <div class="container">
                <div class="text">
                  <div class="title">
                    <span>Paris</span>
                    <span>A Paris Adventure</span>
                  </div>
                  <div class="price">
                    <span>$ 600</span>
                  </div>
                </div>
  
                <div class="btn">
                  <button>Book Flight</button>
                </div>
              </div>
            </div>
          </div>

          <div class="card">
            <img src="/images/flights/main/London.png" alt="">

            <div class="info">
              <div class="container">
                <div class="text">
                  <div class="title">
                    <span>London</span>
                    <span>London eye adventure</span>
                  </div>
                  <div class="price">
                    <span>$ 350</span>
                  </div>
                </div>
  
                <div class="btn">
                  <button>Book Flight</button>
                </div>
              </div>
            </div>
          </div>

          <div class="card">
            <img src="/images/flights/main/Columbia.png" alt="">

            <div class="info">
              <div class="container">
                <div class="text">
                  <div class="title">
                    <span>Columbia</span>
                    <span>Amazing streets</span>
                  </div>
                  <div class="price">
                    <span>$ 700</span>
                  </div>
                </div>
  
                <div class="btn">
                  <button>Book Flight</button>
                </div>
              </div>
            </div>
          </div>
        </div>
    </div>
  </main>
</section>