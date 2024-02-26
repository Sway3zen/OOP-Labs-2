<script>
  import Icon from '@iconify/svelte';
  import { base } from '$app/paths';

  import logo from './img/logo.png';
  import mailbox from './img/mailbox.png';
</script>

<section id="footer">
  <div class="footer">
    <div class="container">
      <div class="logo">
        <img loading="lazy" src="{logo}" alt="">
        <div class="socialMedia">
          <Icon icon="ic:baseline-facebook" />
          <Icon icon="mdi:twitter" />
          <Icon icon="mdi:youtube" />
          <Icon icon="fa6-brands:google-plus" />
        </div>
      </div>

      <div class="block">
        <div class="element">
          <span>Our Destinations</span>

          <div class="items">
            <span>Canada</span>
            <span>Alaska</span>
            <span>France</span>
            <span>Iceland</span>
          </div>
        </div>
        <div class="element">
          <span>Our Activities</span>

          <div class="items">
            <span>Northern Lights</span>
            <span>Cruising & sailing</span>
            <span>Multi-activities</span>
            <span>Kayaing</span>
          </div>
        </div>
        <div class="element">
          <span>Travel Blogs</span>

          <div class="items">
            <span>Bali Travel Guide</span>
            <span>Sri Lanks Travel Guide</span>
            <span>Peru Travel Guide</span>
            <span>Bali Travel Guide</span>
          </div>
        </div>
        <div class="element">
          <span>About us</span>

          <div class="items">
            <span>Our Story</span>
            <span>Work with us</span>
          </div>
        </div>
        <div class="element">
          <span>Contact Us</span>

          <div class="items">
            <span>Our Story</span>
            <span>Work with us</span>
          </div>
        </div>
      </div>
    </div>
  </div>

  <div class="subscribe">
    <div class="container">
      <div class="info">
        <span class="baseTitle">Subscribe <br> Newsletter</span>

        <div class="block">
          <span class="title">The Travel</span>
          <span class="description">Get inspired! Receive travel discounts, tips and behind the scenes stories.</span>

          <div class="form">
            <input type="text" placeholder="Your email address">
            <button>Subscribe</button>
          </div>
        </div>
      </div>
      <div class="picture">
        <img loading="lazy" src="{mailbox}" alt="">
      </div>
    </div>
  </div>
</section>

<style lang="scss">
  #footer {
    width: 100%;
    position: relative;
    .subscribe {
      position: absolute;
      top: -120px;

      margin-left: 7.5%;
      border-radius: 15px;
      width: 85%;

      background: #CDEAE1;
      .container {
        padding: 0 20px;

        display: flex;
        flex-direction: row;
        justify-content: space-between;

        .info {

          display: flex;
          flex-direction: column;
          justify-content: space-between;
          gap: 10px;
          padding: 20px 0;

          .baseTitle {
            font-weight: 700;
            font-size: 28px;
            color: #000;

            height: fit-content;
          }

          .block {
            display: flex;
            flex-direction: column;
            gap: 4px;

            .title {
              font-weight: 550;
              font-size: 20px;
            }

            .description {
              font-weight: 500;
              font-size: 14px;
            }

            .form {
              display: flex;
              flex-direction: row;
              justify-content: space-between;              
              gap: 10px;
              width: 100%;

              input {
                box-sizing: border-box;
                width: 100%;

                border-radius: 4px;

                border: none;
                outline: none;

                font-size: 14px;
                padding: 15px;
              }

              button {
                border: none;
                outline: none;

                font-size: 14px;
                padding: 15px;

                border-radius: 4px;

                color: #FFF;
                background: #000;
              }
            }
          }
        }

        .picture {
          display: flex;
          justify-content: end;
          align-items: end;

          img {
            width: 75%;
            height: auto;
          }
        } 
        
      }
    }

    .footer {
      width: 100%;
      height: auto;
      background: #8DD3BB;

      .container {
        height: auto;
        padding: 140px 7.5% 20px 7.5%;

        display: flex;
        flex-direction: row;
        justify-content: space-between;
        align-items: flex-start;
        
        .logo {
          width: 15%;
          img {
            width: 100px;
            height: auto;
          }

          .socialMedia {
            display: flex;
            flex-direction: row;
            justify-content: space-between;

            width: 100px;
            font-size: 20px;
          }
        }

        .block {
          display: flex;
          flex-direction: row;
          justify-content: space-between;

          width: 85%;
          .element {
            display: flex;
            flex-direction: column;
            align-items: start;
            gap: 9px;

            span {
              font-weight: 700;
              font-size: 18px;

              color: #000;
            }
            .items {
              display: flex;
              flex-direction: column;
              gap: 5px;

              span {
                font-weight: 500;
                font-size: 14px;
                color: #112211;
              }
            }
          }
        }
      }
    }
  }
</style>